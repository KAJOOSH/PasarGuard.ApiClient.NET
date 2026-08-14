using System.Collections;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Tests.Infrastructure;

namespace PasarGuard.ApiClient.Tests;

public sealed class ApiEndpointBehaviorTests
{
    public static IEnumerable<object[]> ApiOperations()
    {
        return OpenApiContract.Operations.Select(operation => new object[]
        {
            operation.OperationId,
            operation.Method,
            operation.Path
        });
    }

    [Theory]
    [MemberData(nameof(ApiOperations))]
    public async Task ApiBuildsRequestExactlyAsOpenApiDefines(string operationId, string expectedMethod, string expectedPathTemplate)
    {
        var operation = OpenApiContract.Operations.Single(item => item.OperationId == operationId);
        var method = FindClientMethod(operationId);
        Assert.Equal(expectedMethod, method.GetCustomAttribute<ApiEndpointAttribute>()!.Method);
        Assert.Equal(expectedPathTemplate, method.GetCustomAttribute<ApiEndpointAttribute>()!.Path);
        AssertSignature(method, operation);

        var recorder = new RequestRecorder();
        using var httpClient = new HttpClient(recorder) { BaseAddress = new Uri("https://pasarguard.test") };
        var client = CreateClient(method.DeclaringType!, httpClient);
        var arguments = CreateArguments(method, operation, out var parameterValues);

        var task = Assert.IsAssignableFrom<Task>(method.Invoke(client, arguments));
        await task;

        Assert.Equal(new HttpMethod(expectedMethod), recorder.Method);
        Assert.Equal(BuildExpectedPath(expectedPathTemplate, operation, parameterValues), recorder.RequestUri!.AbsolutePath);
        AssertQuery(operation, parameterValues, recorder.RequestUri);
        AssertHeaders(operation, parameterValues, recorder.Headers);
        AssertBody(operation, recorder);
    }

    private static MethodInfo FindClientMethod(string operationId)
    {
        var methods = typeof(ApiEndpointAttribute).Assembly.GetTypes()
            .Where(type => type.IsClass && type.Namespace == "PasarGuard.ApiClient.Clients")
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            .Where(method => method.GetCustomAttribute<ApiEndpointAttribute>()?.OperationId == operationId)
            .ToArray();
        return Assert.Single(methods);
    }

    private static object CreateClient(Type clientType, HttpClient httpClient)
    {
        var loggerType = typeof(NullLogger<>).MakeGenericType(clientType);
        var logger = Activator.CreateInstance(loggerType);
        return Activator.CreateInstance(clientType, httpClient, logger)!;
    }

    private static object?[] CreateArguments(MethodInfo method, OperationContract operation, out IReadOnlyDictionary<string, object?> values)
    {
        var openApiParameters = OpenApiContract.GetParameters(operation)
            .ToDictionary(
                parameter => OpenApiContract.GetParameterName(parameter.GetProperty("name").GetString()!),
                parameter => parameter,
                StringComparer.Ordinal);
        var result = new object?[method.GetParameters().Length];
        var samples = new Dictionary<string, object?>(StringComparer.Ordinal);

        for (var index = 0; index < method.GetParameters().Length; index++)
        {
            var parameter = method.GetParameters()[index];
            if (parameter.ParameterType == typeof(CancellationToken))
            {
                result[index] = CancellationToken.None;
                continue;
            }

            if (parameter.Name == "request")
            {
                result[index] = SampleValueFactory.Create(parameter.ParameterType);
                continue;
            }

            var definition = openApiParameters[parameter.Name!];
            var location = definition.GetProperty("in").GetString()!;
            var sample = SampleValueFactory.CreateParameter(parameter.ParameterType, location);
            result[index] = sample;
            samples[$"{location}:{definition.GetProperty("name").GetString()}"] = sample;
        }

        values = samples;
        return result;
    }

    private static void AssertSignature(MethodInfo method, OperationContract operation)
    {
        var methodParameters = method.GetParameters().Where(parameter => parameter.ParameterType != typeof(CancellationToken)).ToArray();
        var openApiParameters = OpenApiContract.GetParameters(operation);
        var hasBody = operation.Definition.TryGetProperty("requestBody", out var requestBody);
        Assert.Equal(openApiParameters.Count + (hasBody ? 1 : 0), methodParameters.Length);

        foreach (var definition in openApiParameters)
        {
            var parameterName = OpenApiContract.GetParameterName(definition.GetProperty("name").GetString()!);
            var parameter = Assert.Single(methodParameters, item => item.Name == parameterName);
            var schema = definition.GetProperty("schema");
            var required = definition.TryGetProperty("required", out var requiredElement) && requiredElement.GetBoolean();
            var expectedType = GetExpectedParameterType(schema, required);
            Assert.Equal(expectedType, parameter.ParameterType);
            AssertParameterDefault(parameter, schema, required);
        }

        if (hasBody)
        {
            var requestParameter = Assert.Single(methodParameters, parameter => parameter.Name == "request");
            var bodySchema = GetRequestMedia(requestBody).Value.GetProperty("schema");
            Assert.Equal(OpenApiContract.MapSchemaType(bodySchema), requestParameter.ParameterType);
        }

        AssertResponseType(method, operation);
    }

    private static Type GetExpectedParameterType(JsonElement schema, bool required)
    {
        var normalized = OpenApiContract.NormalizeSchema(schema);
        var type = OpenApiContract.MapSchemaType(schema);
        var hasDefault = schema.TryGetProperty("default", out var defaultValue);
        var nullable = normalized.Nullable || (!required && !hasDefault) || (hasDefault && defaultValue.ValueKind == JsonValueKind.Null);
        return nullable && type.IsValueType ? typeof(Nullable<>).MakeGenericType(type) : type;
    }

    private static void AssertParameterDefault(ParameterInfo parameter, JsonElement schema, bool required)
    {
        if (schema.TryGetProperty("default", out var defaultValue))
        {
            Assert.True(parameter.HasDefaultValue);
            Assert.Equal(GetJsonValue(defaultValue), GetComparableValue(parameter.DefaultValue));
            return;
        }

        if (!required)
        {
            Assert.True(parameter.HasDefaultValue);
            Assert.Null(parameter.DefaultValue);
            return;
        }

        Assert.False(parameter.HasDefaultValue);
    }

    private static void AssertResponseType(MethodInfo method, OperationContract operation)
    {
        var taskResult = method.ReturnType.GetGenericArguments().Single();
        var expectedValueType = GetExpectedResponseType(operation);
        if (expectedValueType is null)
        {
            Assert.Equal(typeof(ApiResult), taskResult);
            return;
        }

        Assert.True(taskResult.IsGenericType);
        Assert.Equal(typeof(ApiResult<>), taskResult.GetGenericTypeDefinition());
        Assert.Equal(expectedValueType, taskResult.GetGenericArguments().Single());
    }

    private static Type? GetExpectedResponseType(OperationContract operation)
    {
        var success = operation.Definition.GetProperty("responses").EnumerateObject()
            .Where(item => item.Name.Length == 3 && item.Name[0] == '2')
            .OrderBy(item => item.Name, StringComparer.Ordinal)
            .First();
        if (!success.Value.TryGetProperty("content", out var content) || !content.EnumerateObject().Any())
        {
            return null;
        }

        var media = content.EnumerateObject().First();
        if (media.Name.StartsWith("text/", StringComparison.OrdinalIgnoreCase))
        {
            return typeof(string);
        }

        if (!media.Value.TryGetProperty("schema", out var schema) || !schema.EnumerateObject().Any())
        {
            return operation.Method == "HEAD"
                ? null
                : operation.Path.StartsWith("/sub/", StringComparison.Ordinal)
                    ? typeof(string)
                    : typeof(JsonElement);
        }

        return OpenApiContract.MapSchemaType(schema);
    }

    private static string BuildExpectedPath(string pathTemplate, OperationContract operation, IReadOnlyDictionary<string, object?> values)
    {
        var path = pathTemplate;
        foreach (var parameter in OpenApiContract.GetParameters(operation).Where(item => item.GetProperty("in").GetString() == "path"))
        {
            var name = parameter.GetProperty("name").GetString()!;
            var value = values[$"path:{name}"]!;
            path = path.Replace($"{{{name}}}", Uri.EscapeDataString(FormatValue(value)), StringComparison.Ordinal);
        }

        return path;
    }

    private static void AssertQuery(OperationContract operation, IReadOnlyDictionary<string, object?> values, Uri requestUri)
    {
        var expected = new Dictionary<string, IReadOnlyList<string>>(StringComparer.Ordinal);
        foreach (var parameter in OpenApiContract.GetParameters(operation).Where(item => item.GetProperty("in").GetString() == "query"))
        {
            var name = parameter.GetProperty("name").GetString()!;
            expected[name] = ExpandValues(values[$"query:{name}"]).Select(FormatValue).ToArray();
        }

        var actual = ParseFormEncoded(requestUri.Query.TrimStart('?'));
        Assert.Equal(expected.Keys.OrderBy(item => item, StringComparer.Ordinal), actual.Keys.OrderBy(item => item, StringComparer.Ordinal));
        foreach (var item in expected)
        {
            Assert.Equal(item.Value, actual[item.Key]);
        }
    }

    private static void AssertHeaders(OperationContract operation, IReadOnlyDictionary<string, object?> values, IReadOnlyDictionary<string, IReadOnlyList<string>> actual)
    {
        foreach (var parameter in OpenApiContract.GetParameters(operation).Where(item => item.GetProperty("in").GetString() == "header"))
        {
            var name = parameter.GetProperty("name").GetString()!;
            Assert.True(actual.TryGetValue(name, out var actualValues), $"Header '{name}' was not sent.");
            Assert.Equal(new[] { FormatValue(values[$"header:{name}"]!) }, actualValues);
        }
    }

    private static void AssertBody(OperationContract operation, RequestRecorder recorder)
    {
        if (!operation.Definition.TryGetProperty("requestBody", out var requestBody))
        {
            Assert.Null(recorder.Body);
            Assert.Null(recorder.ContentType);
            return;
        }

        var media = GetRequestMedia(requestBody);
        Assert.Equal(media.Name, recorder.ContentType);
        Assert.NotNull(recorder.Body);
        var schema = OpenApiContract.ResolveReference(OpenApiContract.NormalizeSchema(media.Value.GetProperty("schema")).Schema);

        if (media.Name == "application/x-www-form-urlencoded")
        {
            var propertyNames = GetSchemaPropertyNames(schema);
            var requiredNames = GetRequiredPropertyNames(schema);
            var values = ParseFormEncoded(recorder.Body!);
            Assert.All(requiredNames, name => Assert.Contains(name, values.Keys));
            Assert.All(values.Keys, name => Assert.Contains(name, propertyNames));
            return;
        }

        using var body = JsonDocument.Parse(recorder.Body!);
        if (schema.TryGetProperty("type", out var schemaType) && schemaType.GetString() == "array")
        {
            Assert.Equal(JsonValueKind.Array, body.RootElement.ValueKind);
            var itemSchema = OpenApiContract.ResolveReference(OpenApiContract.NormalizeSchema(schema.GetProperty("items")).Schema);
            Assert.All(body.RootElement.EnumerateArray(), item => AssertJsonObject(item, itemSchema));
            return;
        }

        AssertJsonObject(body.RootElement, schema);
    }

    private static void AssertJsonObject(JsonElement value, JsonElement schema)
    {
        Assert.Equal(JsonValueKind.Object, value.ValueKind);
        var propertyNames = GetSchemaPropertyNames(schema);
        var requiredNames = GetRequiredPropertyNames(schema);
        var bodyNames = value.EnumerateObject().Select(item => item.Name).ToArray();
        Assert.All(requiredNames, name => Assert.Contains(name, bodyNames));
        var allowsAdditional = schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.True;
        if (!allowsAdditional)
        {
            Assert.All(bodyNames, name => Assert.Contains(name, propertyNames));
        }
    }

    private static HashSet<string> GetSchemaPropertyNames(JsonElement schema)
    {
        return schema.TryGetProperty("properties", out var properties)
            ? properties.EnumerateObject().Select(item => item.Name).ToHashSet(StringComparer.Ordinal)
            : new HashSet<string>(StringComparer.Ordinal);
    }

    private static string[] GetRequiredPropertyNames(JsonElement schema)
    {
        return schema.TryGetProperty("required", out var required)
            ? required.EnumerateArray().Select(item => item.GetString()!).ToArray()
            : [];
    }

    private static JsonProperty GetRequestMedia(JsonElement requestBody)
    {
        var content = requestBody.GetProperty("content");
        var json = content.EnumerateObject().FirstOrDefault(item => item.NameEquals("application/json"));
        return json.Value.ValueKind == JsonValueKind.Undefined ? content.EnumerateObject().First() : json;
    }

    private static IReadOnlyDictionary<string, IReadOnlyList<string>> ParseFormEncoded(string content)
    {
        if (string.IsNullOrEmpty(content))
        {
            return new Dictionary<string, IReadOnlyList<string>>(StringComparer.Ordinal);
        }

        return content.Split('&', StringSplitOptions.RemoveEmptyEntries)
            .Select(item => item.Split('=', 2))
            .Select(parts => new KeyValuePair<string, string>(Decode(parts[0]), Decode(parts.Length == 2 ? parts[1] : string.Empty)))
            .GroupBy(item => item.Key, StringComparer.Ordinal)
            .ToDictionary(
                group => group.Key,
                group => (IReadOnlyList<string>)group.Select(item => item.Value).ToArray(),
                StringComparer.Ordinal);
    }

    private static string Decode(string value)
    {
        return Uri.UnescapeDataString(value.Replace('+', ' '));
    }

    private static IEnumerable<object> ExpandValues(object? value)
    {
        if (value is not string && value is not JsonElement && value is IEnumerable enumerable)
        {
            return enumerable.Cast<object>();
        }

        return value is null ? [] : [value];
    }

    private static string FormatValue(object value)
    {
        return value switch
        {
            string text => text,
            bool boolean => boolean ? "true" : "false",
            DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("O", CultureInfo.InvariantCulture),
            DateTime dateTime => dateTime.ToString("O", CultureInfo.InvariantCulture),
            DateOnly dateOnly => dateOnly.ToString("O", CultureInfo.InvariantCulture),
            Enum enumValue => enumValue.GetType().GetMember(enumValue.ToString()).Single().GetCustomAttribute<EnumMemberAttribute>()?.Value ?? enumValue.ToString(),
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };
    }

    private static object? GetJsonValue(JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.String => value.GetString(),
            JsonValueKind.Number when value.TryGetInt64(out var integer) => integer.ToString(CultureInfo.InvariantCulture),
            JsonValueKind.Number => value.GetDouble().ToString(CultureInfo.InvariantCulture),
            JsonValueKind.True => "true",
            JsonValueKind.False => "false",
            JsonValueKind.Null => null,
            _ => value.GetRawText()
        };
    }

    private static object? GetComparableValue(object? value)
    {
        return value switch
        {
            null => null,
            Enum enumValue => FormatValue(enumValue),
            bool boolean => boolean ? "true" : "false",
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString()
        };
    }
}
