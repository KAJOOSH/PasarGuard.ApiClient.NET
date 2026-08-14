using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

if (args.Length != 2)
{
    Console.Error.WriteLine("Usage: PasarGuard.ApiClient.CodeGen <openapi.json> <repository-root>");
    return 1;
}

var specificationPath = Path.GetFullPath(args[0]);
var repositoryRoot = Path.GetFullPath(args[1]);
using var document = JsonDocument.Parse(File.ReadAllText(specificationPath));
var generator = new OpenApiGenerator(document.RootElement, repositoryRoot);
generator.Generate();
return 0;

internal sealed class OpenApiGenerator
{
    private static readonly HashSet<string> HttpMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "get", "post", "put", "patch", "delete", "head", "options", "trace"
    };

    private static readonly Dictionary<string, string> TagNames = new(StringComparer.Ordinal)
    {
        [""] = "Default",
        ["Admin"] = "Admin",
        ["Admin Roles"] = "AdminRoles",
        ["API Keys"] = "ApiKeys",
        ["Client Template"] = "ClientTemplate",
        ["Core"] = "Core",
        ["Groups"] = "Groups",
        ["Host"] = "Host",
        ["Node"] = "Node",
        ["Settings"] = "Settings",
        ["Setup"] = "Setup",
        ["Subscription"] = "Subscription",
        ["System"] = "System",
        ["User"] = "User",
        ["User HWID"] = "UserHwid",
        ["User Template"] = "UserTemplate"
    };

    private readonly JsonElement root;
    private readonly string repositoryRoot;
    private readonly string modelsDirectory;
    private readonly string clientsDirectory;
    private readonly string abstractionsDirectory;
    private readonly Dictionary<string, string> schemaTypeNames;

    public OpenApiGenerator(JsonElement root, string repositoryRoot)
    {
        this.root = root;
        this.repositoryRoot = repositoryRoot;
        modelsDirectory = Path.Combine(repositoryRoot, "src", "PasarGuard.ApiClient", "Models");
        clientsDirectory = Path.Combine(repositoryRoot, "src", "PasarGuard.ApiClient", "Clients");
        abstractionsDirectory = Path.Combine(repositoryRoot, "src", "PasarGuard.ApiClient", "Abstractions");
        schemaTypeNames = root.GetProperty("components").GetProperty("schemas")
            .EnumerateObject()
            .ToDictionary(item => item.Name, item => Naming.TypeName(item.Name), StringComparer.Ordinal);
    }

    public void Generate()
    {
        Directory.CreateDirectory(modelsDirectory);
        Directory.CreateDirectory(clientsDirectory);
        Directory.CreateDirectory(abstractionsDirectory);
        DeleteCSharpFiles(modelsDirectory);
        DeleteCSharpFiles(clientsDirectory);
        DeleteCSharpFiles(abstractionsDirectory);
        GenerateModels();
        var operations = ReadOperations();
        GenerateClients(operations);
        GenerateAggregateClient(operations.Select(item => item.ClientName).Distinct(StringComparer.Ordinal).OrderBy(item => item, StringComparer.Ordinal).ToArray());
        Console.WriteLine($"Generated {schemaTypeNames.Count} models and {operations.Count} operations for PasarGuardAPI {root.GetProperty("info").GetProperty("version").GetString()}.");
    }

    private static void DeleteCSharpFiles(string directory)
    {
        foreach (var path in Directory.EnumerateFiles(directory, "*.cs", SearchOption.TopDirectoryOnly))
        {
            File.Delete(path);
        }
    }

    private void GenerateModels()
    {
        foreach (var schema in root.GetProperty("components").GetProperty("schemas").EnumerateObject())
        {
            var typeName = schemaTypeNames[schema.Name];
            var source = schema.Value.TryGetProperty("enum", out _) ? GenerateEnum(typeName, schema.Value) : GenerateRecord(typeName, schema.Value);
            File.WriteAllText(Path.Combine(modelsDirectory, $"{typeName}.cs"), source, new UTF8Encoding(false));
        }
    }

    private static string GenerateEnum(string typeName, JsonElement schema)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Runtime.Serialization;");
        builder.AppendLine("using System.Text.Json.Serialization;");
        builder.AppendLine("using PasarGuard.ApiClient.Serialization;");
        builder.AppendLine();
        builder.AppendLine("namespace PasarGuard.ApiClient.Models;");
        builder.AppendLine();
        builder.AppendLine($"[JsonConverter(typeof(PasarGuardEnumJsonConverter<{typeName}>))]");
        builder.AppendLine($"public enum {typeName}");
        builder.AppendLine("{");
        var usedNames = new HashSet<string>(StringComparer.Ordinal);
        var values = schema.GetProperty("enum").EnumerateArray().ToArray();
        for (var index = 0; index < values.Length; index++)
        {
            var serializedValue = values[index].ValueKind == JsonValueKind.String ? values[index].GetString() ?? string.Empty : values[index].GetRawText();
            var memberName = Naming.EnumMember(serializedValue, index);
            var uniqueName = memberName;
            var suffix = 2;
            while (!usedNames.Add(uniqueName))
            {
                uniqueName = $"{memberName}{suffix++}";
            }

            builder.AppendLine($"    [EnumMember(Value = \"{Escape(serializedValue)}\")]");
            builder.Append("    ").Append(uniqueName);
            builder.AppendLine(index == values.Length - 1 ? string.Empty : ",");
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private string GenerateRecord(string typeName, JsonElement schema)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json;");
        builder.AppendLine("using System.Text.Json.Serialization;");
        builder.AppendLine();
        builder.AppendLine("namespace PasarGuard.ApiClient.Models;");
        builder.AppendLine();
        builder.AppendLine($"public sealed record {typeName}");
        builder.AppendLine("{");
        var requiredNames = schema.TryGetProperty("required", out var required)
            ? required.EnumerateArray().Select(item => item.GetString() ?? string.Empty).ToHashSet(StringComparer.Ordinal)
            : new HashSet<string>(StringComparer.Ordinal);
        var hasMembers = false;

        if (schema.TryGetProperty("properties", out var properties))
        {
            foreach (var property in properties.EnumerateObject())
            {
                AppendProperty(builder, property, requiredNames.Contains(property.Name), typeName);
                hasMembers = true;
            }
        }

        if (schema.TryGetProperty("additionalProperties", out var additionalProperties) && additionalProperties.ValueKind == JsonValueKind.True)
        {
            builder.AppendLine("    [JsonExtensionData]");
            builder.AppendLine("    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];");
            builder.AppendLine();
            hasMembers = true;
        }

        if (hasMembers)
        {
            builder.Length -= Environment.NewLine.Length;
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private void AppendProperty(StringBuilder builder, JsonProperty property, bool required, string ownerTypeName)
    {
        var resolved = ResolveSchema(property.Value);
        var type = GetTypeReference(resolved.Schema, ownerTypeName);
        var hasDefault = property.Value.TryGetProperty("default", out var defaultValue);
        var nullable = resolved.Nullable || (!required && !hasDefault) || (hasDefault && defaultValue.ValueKind == JsonValueKind.Null);
        var typeText = nullable ? MakeNullable(type) : type;
        var propertyName = Naming.PropertyName(property.Name);
        builder.AppendLine($"    [JsonPropertyName(\"{Escape(property.Name)}\")]");
        builder.Append("    public ");
        if (required && !hasDefault)
        {
            builder.Append("required ");
        }

        builder.Append(typeText).Append(' ').Append(propertyName).Append(" { get; init; }");
        var initializer = hasDefault ? GetInitializer(defaultValue, type, resolved.Schema) : null;
        if (initializer is not null)
        {
            builder.Append(" = ").Append(initializer).Append(';');
        }

        builder.AppendLine();
        builder.AppendLine();
    }

    private List<Operation> ReadOperations()
    {
        var operations = new List<Operation>();
        foreach (var pathProperty in root.GetProperty("paths").EnumerateObject())
        {
            var pathParameters = ReadParameters(pathProperty.Value);
            foreach (var methodProperty in pathProperty.Value.EnumerateObject().Where(item => HttpMethods.Contains(item.Name)))
            {
                var operation = methodProperty.Value;
                var tag = operation.TryGetProperty("tags", out var tags) && tags.GetArrayLength() > 0 ? tags[0].GetString() ?? string.Empty : string.Empty;
                if (!TagNames.TryGetValue(tag, out var clientName))
                {
                    clientName = Naming.TypeName(tag);
                }

                var parameters = pathParameters.Concat(ReadParameters(operation)).GroupBy(item => (item.Location, item.JsonName)).Select(item => item.Last()).ToList();
                var requestBody = ReadRequestBody(operation);
                operations.Add(new Operation(
                    clientName,
                    methodProperty.Name.ToUpperInvariant(),
                    pathProperty.Name,
                    operation.GetProperty("operationId").GetString() ?? string.Empty,
                    Naming.MethodName(operation.GetProperty("operationId").GetString() ?? string.Empty),
                    parameters,
                    requestBody,
                    ReadResponse(operation, methodProperty.Name, pathProperty.Name)));
            }
        }

        return operations;
    }

    private List<Parameter> ReadParameters(JsonElement owner)
    {
        var result = new List<Parameter>();
        if (!owner.TryGetProperty("parameters", out var parameters))
        {
            return result;
        }

        foreach (var parameter in parameters.EnumerateArray())
        {
            var schema = parameter.GetProperty("schema");
            var resolved = ResolveSchema(schema);
            var required = parameter.TryGetProperty("required", out var requiredElement) && requiredElement.GetBoolean();
            var hasDefault = schema.TryGetProperty("default", out var defaultElement);
            var type = GetTypeReference(resolved.Schema);
            var nullable = resolved.Nullable || (!required && !hasDefault);
            var defaultValue = hasDefault ? GetParameterDefault(defaultElement, type, resolved.Schema) : null;
            result.Add(new Parameter(
                parameter.GetProperty("name").GetString() ?? string.Empty,
                Naming.ParameterName(parameter.GetProperty("name").GetString() ?? string.Empty),
                parameter.GetProperty("in").GetString() ?? string.Empty,
                nullable ? MakeNullable(type) : type,
                required,
                defaultValue));
        }

        return result;
    }

    private RequestBody? ReadRequestBody(JsonElement operation)
    {
        if (!operation.TryGetProperty("requestBody", out var body))
        {
            return null;
        }

        var required = body.TryGetProperty("required", out var requiredElement) && requiredElement.GetBoolean();
        var content = body.GetProperty("content");
        var media = content.EnumerateObject().FirstOrDefault(item => item.NameEquals("application/json"));
        if (media.Value.ValueKind == JsonValueKind.Undefined)
        {
            media = content.EnumerateObject().First();
        }

        var schema = media.Value.GetProperty("schema");
        var type = GetTypeReference(ResolveSchema(schema).Schema);
        var kind = media.Name == "application/x-www-form-urlencoded" ? "RequestBodyKind.FormUrlEncoded" : "RequestBodyKind.Json";
        return new RequestBody(required ? type : MakeNullable(type), required, kind);
    }

    private Response ReadResponse(JsonElement operation, string method, string path)
    {
        var success = operation.GetProperty("responses").EnumerateObject()
            .Where(item => item.Name.Length == 3 && item.Name[0] == '2')
            .OrderBy(item => item.Name, StringComparer.Ordinal)
            .FirstOrDefault();
        if (success.Value.ValueKind == JsonValueKind.Undefined || !success.Value.TryGetProperty("content", out var content) || !content.EnumerateObject().Any())
        {
            return new Response(null);
        }

        var media = content.EnumerateObject().First();
        if (media.Name.StartsWith("text/", StringComparison.OrdinalIgnoreCase))
        {
            return new Response("string");
        }

        if (!media.Value.TryGetProperty("schema", out var schema) || !schema.EnumerateObject().Any())
        {
            return new Response(method.Equals("head", StringComparison.OrdinalIgnoreCase) ? null : path.StartsWith("/sub/", StringComparison.Ordinal) ? "string" : "JsonElement");
        }

        return new Response(GetTypeReference(ResolveSchema(schema).Schema));
    }

    private void GenerateClients(IReadOnlyList<Operation> operations)
    {
        foreach (var group in operations.GroupBy(item => item.ClientName).OrderBy(item => item.Key, StringComparer.Ordinal))
        {
            var ordered = group.OrderBy(item => item.Path, StringComparer.Ordinal).ThenBy(item => item.Method, StringComparer.Ordinal).ToArray();
            File.WriteAllText(Path.Combine(clientsDirectory, $"{group.Key}Client.cs"), GenerateClient(group.Key, ordered), new UTF8Encoding(false));
            File.WriteAllText(Path.Combine(abstractionsDirectory, $"I{group.Key}Client.cs"), GenerateInterface(group.Key, ordered), new UTF8Encoding(false));
        }
    }

    private static string GenerateClient(string clientName, IReadOnlyList<Operation> operations)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json;");
        builder.AppendLine("using Microsoft.Extensions.Logging;");
        builder.AppendLine("using PasarGuard.ApiClient.Abstractions;");
        builder.AppendLine("using PasarGuard.ApiClient.Core;");
        builder.AppendLine("using PasarGuard.ApiClient.Internal;");
        builder.AppendLine("using PasarGuard.ApiClient.Models;");
        builder.AppendLine();
        builder.AppendLine("namespace PasarGuard.ApiClient.Clients;");
        builder.AppendLine();
        builder.AppendLine($"public sealed class {clientName}Client : ApiClientBase, I{clientName}Client");
        builder.AppendLine("{");
        builder.AppendLine($"    public {clientName}Client(HttpClient httpClient, ILogger<{clientName}Client> logger) : base(httpClient, logger)");
        builder.AppendLine("    {");
        builder.AppendLine("    }");
        foreach (var operation in operations)
        {
            builder.AppendLine();
            AppendClientMethod(builder, operation);
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private static string GenerateInterface(string clientName, IReadOnlyList<Operation> operations)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json;");
        builder.AppendLine("using PasarGuard.ApiClient.Core;");
        builder.AppendLine("using PasarGuard.ApiClient.Models;");
        builder.AppendLine();
        builder.AppendLine("namespace PasarGuard.ApiClient.Abstractions;");
        builder.AppendLine();
        builder.AppendLine($"public interface I{clientName}Client");
        builder.AppendLine("{");
        for (var index = 0; index < operations.Count; index++)
        {
            var operation = operations[index];
            builder.AppendLine($"    [ApiEndpoint(\"{Escape(operation.Method)}\", \"{Escape(operation.Path)}\", \"{Escape(operation.OperationId)}\")]");
            builder.Append("    ").Append(GetReturnType(operation)).Append(' ').Append(operation.MethodName).Append("Async(").Append(GetParameters(operation)).AppendLine(");");
            if (index != operations.Count - 1)
            {
                builder.AppendLine();
            }
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private static void AppendClientMethod(StringBuilder builder, Operation operation)
    {
        builder.AppendLine($"    [ApiEndpoint(\"{Escape(operation.Method)}\", \"{Escape(operation.Path)}\", \"{Escape(operation.OperationId)}\")]");
        builder.Append("    public ").Append(GetReturnType(operation)).Append(' ').Append(operation.MethodName).Append("Async(").Append(GetParameters(operation)).AppendLine(")");
        builder.AppendLine("    {");
        var interpolatedPath = operation.Path;
        foreach (var parameter in operation.Parameters.Where(item => item.Location == "path"))
        {
            interpolatedPath = interpolatedPath.Replace($"{{{parameter.JsonName}}}", $"{{UrlEncoding.EncodePathSegment({parameter.Name})}}", StringComparison.Ordinal);
        }

        var prefix = operation.Parameters.Any(item => item.Location == "path") ? "$" : string.Empty;
        builder.AppendLine($"        var path = {prefix}\"{Escape(interpolatedPath)}\";");
        var queryParameters = operation.Parameters.Where(item => item.Location == "query").ToArray();
        if (queryParameters.Length > 0)
        {
            builder.AppendLine("        var query = new QueryStringBuilder()");
            for (var index = 0; index < queryParameters.Length; index++)
            {
                var ending = index == queryParameters.Length - 1 ? ";" : string.Empty;
                builder.AppendLine($"            .Add(\"{Escape(queryParameters[index].JsonName)}\", {queryParameters[index].Name}){ending}");
            }

            builder.AppendLine("        var url = query.Build(path);");
        }
        else
        {
            builder.AppendLine("        var url = path;");
        }

        var headerParameters = operation.Parameters.Where(item => item.Location == "header").ToArray();
        if (headerParameters.Length > 0)
        {
            builder.AppendLine("        var headers = new Dictionary<string, string?>");
            builder.AppendLine("        {");
            for (var index = 0; index < headerParameters.Length; index++)
            {
                var ending = index == headerParameters.Length - 1 ? string.Empty : ",";
                builder.AppendLine($"            [\"{Escape(headerParameters[index].JsonName)}\"] = ValueFormatter.FormatNullable({headerParameters[index].Name}){ending}");
            }

            builder.AppendLine("        };");
        }

        var responseType = operation.Response.Type;
        var generic = responseType is null ? string.Empty : $"<{responseType}>";
        var body = operation.RequestBody is null ? "null" : "request";
        var bodyKind = operation.RequestBody?.Kind ?? "RequestBodyKind.None";
        var headersArgument = headerParameters.Length == 0 ? "null" : "headers";
        builder.AppendLine($"        return SendAsync{generic}(HttpMethod.{Naming.HttpMethod(operation.Method)}, url, {body}, {bodyKind}, {headersArgument}, cancellationToken);");
        builder.AppendLine("    }");
    }

    private static string GetReturnType(Operation operation)
    {
        return operation.Response.Type is null ? "Task<ApiResult>" : $"Task<ApiResult<{operation.Response.Type}>>";
    }

    private static string GetParameters(Operation operation)
    {
        var requiredParameters = operation.Parameters.Where(item => item.Required && item.DefaultValue is null).ToList();
        var optionalParameters = operation.Parameters.Where(item => !item.Required || item.DefaultValue is not null).ToList();
        var parts = new List<string>();
        parts.AddRange(requiredParameters.Select(FormatParameter));
        if (operation.RequestBody is { Required: true } body)
        {
            parts.Add($"{body.Type} request");
        }

        parts.AddRange(optionalParameters.Select(FormatParameter));
        if (operation.RequestBody is { Required: false } optionalBody)
        {
            parts.Add($"{optionalBody.Type} request = null");
        }

        parts.Add("CancellationToken cancellationToken = default");
        return string.Join(", ", parts);
    }

    private static string FormatParameter(Parameter parameter)
    {
        if (parameter.DefaultValue is not null)
        {
            return $"{parameter.Type} {parameter.Name} = {parameter.DefaultValue}";
        }

        return parameter.Required ? $"{parameter.Type} {parameter.Name}" : $"{parameter.Type} {parameter.Name} = null";
    }

    private void GenerateAggregateClient(IReadOnlyList<string> clientNames)
    {
        var interfaceBuilder = new StringBuilder();
        interfaceBuilder.AppendLine("namespace PasarGuard.ApiClient.Abstractions;");
        interfaceBuilder.AppendLine();
        interfaceBuilder.AppendLine("public interface IPasarGuardApiClient");
        interfaceBuilder.AppendLine("{");
        foreach (var name in clientNames)
        {
            interfaceBuilder.AppendLine($"    I{name}Client {name} {{ get; }}");
        }

        interfaceBuilder.AppendLine("}");
        File.WriteAllText(Path.Combine(abstractionsDirectory, "IPasarGuardApiClient.cs"), interfaceBuilder.ToString(), new UTF8Encoding(false));

        var clientBuilder = new StringBuilder();
        clientBuilder.AppendLine("using PasarGuard.ApiClient.Abstractions;");
        clientBuilder.AppendLine();
        clientBuilder.AppendLine("namespace PasarGuard.ApiClient.Clients;");
        clientBuilder.AppendLine();
        clientBuilder.AppendLine("public sealed class PasarGuardApiClient : IPasarGuardApiClient");
        clientBuilder.AppendLine("{");
        clientBuilder.Append("    public PasarGuardApiClient(");
        clientBuilder.Append(string.Join(", ", clientNames.Select(name => $"I{name}Client {Naming.ParameterName(name)}")));
        clientBuilder.AppendLine(")");
        clientBuilder.AppendLine("    {");
        foreach (var name in clientNames)
        {
            clientBuilder.AppendLine($"        {name} = {Naming.ParameterName(name)};");
        }

        clientBuilder.AppendLine("    }");
        foreach (var name in clientNames)
        {
            clientBuilder.AppendLine();
            clientBuilder.AppendLine($"    public I{name}Client {name} {{ get; }}");
        }

        clientBuilder.AppendLine("}");
        File.WriteAllText(Path.Combine(clientsDirectory, "PasarGuardApiClient.cs"), clientBuilder.ToString(), new UTF8Encoding(false));
    }

    private string GetTypeReference(JsonElement schema, string? contextName = null)
    {
        if (schema.TryGetProperty("$ref", out var reference))
        {
            var schemaName = reference.GetString()?.Split('/').Last() ?? string.Empty;
            return schemaTypeNames.TryGetValue(schemaName, out var typeName) ? typeName : Naming.TypeName(schemaName);
        }

        if (schema.TryGetProperty("enum", out _))
        {
            return FindMatchingEnumType(schema, contextName) ?? "string";
        }

        var type = schema.TryGetProperty("type", out var typeElement) ? typeElement.GetString() : null;
        return type switch
        {
            "string" when schema.TryGetProperty("format", out var format) && format.GetString() == "date-time" => "DateTimeOffset",
            "string" when schema.TryGetProperty("format", out var format) && format.GetString() == "date" => "DateOnly",
            "string" => "string",
            "integer" when schema.TryGetProperty("format", out var format) && format.GetString() == "int32" => "int",
            "integer" => "long",
            "number" when schema.TryGetProperty("format", out var format) && format.GetString() == "float" => "float",
            "number" when schema.TryGetProperty("format", out var format) && format.GetString() == "decimal" => "decimal",
            "number" => "double",
            "boolean" => "bool",
            "array" => $"IReadOnlyList<{GetTypeReference(ResolveSchema(schema.GetProperty("items")).Schema)}>",
            "object" when schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.Object => $"IReadOnlyDictionary<string, {GetTypeReference(ResolveSchema(additional).Schema)}>",
            "object" when schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.True => "IReadOnlyDictionary<string, JsonElement>",
            "object" => "JsonElement",
            _ => "JsonElement"
        };
    }

    private static ResolvedSchema ResolveSchema(JsonElement schema)
    {
        if (!schema.TryGetProperty("anyOf", out var anyOf))
        {
            return new ResolvedSchema(schema, false);
        }

        var candidates = anyOf.EnumerateArray().Where(item => !item.TryGetProperty("type", out var type) || type.GetString() != "null").ToArray();
        var nullable = candidates.Length != anyOf.GetArrayLength();
        return candidates.Length == 1 ? new ResolvedSchema(candidates[0], nullable) : new ResolvedSchema(schema, nullable);
    }

    private string? GetInitializer(JsonElement value, string type, JsonElement schema)
    {
        return value.ValueKind switch
        {
            JsonValueKind.String when IsEnumReference(schema, out var enumSchema) => $"{type}.{GetEnumMemberForValue(enumSchema, value.GetString() ?? string.Empty)}",
            JsonValueKind.String when schema.TryGetProperty("enum", out _) && type != "string" => $"{type}.{GetEnumMemberForValue(schema, value.GetString() ?? string.Empty)}",
            JsonValueKind.String => $"\"{Escape(value.GetString() ?? string.Empty)}\"",
            JsonValueKind.True => "true",
            JsonValueKind.False => "false",
            JsonValueKind.Number => NormalizeNumber(value.GetRawText(), type),
            JsonValueKind.Array when value.GetArrayLength() == 0 => "[]",
            JsonValueKind.Object when !value.EnumerateObject().Any() && type.StartsWith("IReadOnlyDictionary<", StringComparison.Ordinal) => "[]",
            JsonValueKind.Null => "null",
            _ => null
        };
    }

    private string? GetParameterDefault(JsonElement value, string type, JsonElement schema)
    {
        return value.ValueKind switch
        {
            JsonValueKind.String when IsEnumReference(schema, out var enumSchema) => $"{type}.{GetEnumMemberForValue(enumSchema, value.GetString() ?? string.Empty)}",
            JsonValueKind.String when schema.TryGetProperty("enum", out _) && type != "string" => $"{type}.{GetEnumMemberForValue(schema, value.GetString() ?? string.Empty)}",
            JsonValueKind.String => $"\"{Escape(value.GetString() ?? string.Empty)}\"",
            JsonValueKind.True => "true",
            JsonValueKind.False => "false",
            JsonValueKind.Number => NormalizeNumber(value.GetRawText(), type),
            JsonValueKind.Null => "null",
            _ => null
        };
    }

    private bool IsEnumReference(JsonElement schema, out JsonElement enumSchema)
    {
        enumSchema = default;
        if (!schema.TryGetProperty("$ref", out var reference))
        {
            return false;
        }

        var schemaName = reference.GetString()?.Split('/').Last() ?? string.Empty;
        return root.GetProperty("components").GetProperty("schemas").TryGetProperty(schemaName, out enumSchema) && enumSchema.TryGetProperty("enum", out _);
    }

    private string? FindMatchingEnumType(JsonElement schema, string? contextName)
    {
        if (!schema.TryGetProperty("enum", out var values))
        {
            return null;
        }

        var expected = values.EnumerateArray().Select(GetComparableValue).ToHashSet(StringComparer.Ordinal);
        return root.GetProperty("components").GetProperty("schemas").EnumerateObject()
            .Where(item => item.Value.TryGetProperty("enum", out var candidateValues) && expected.IsSubsetOf(candidateValues.EnumerateArray().Select(GetComparableValue)))
            .OrderByDescending(item => SharedPrefixLength(schemaTypeNames[item.Name], contextName))
            .ThenBy(item => item.Value.GetProperty("enum").GetArrayLength())
            .ThenBy(item => item.Name, StringComparer.Ordinal)
            .Select(item => schemaTypeNames[item.Name])
            .FirstOrDefault();
    }

    private static string GetComparableValue(JsonElement value)
    {
        return value.ValueKind == JsonValueKind.String ? value.GetString() ?? string.Empty : value.GetRawText();
    }

    private static int SharedPrefixLength(string value, string? context)
    {
        if (string.IsNullOrEmpty(context))
        {
            return 0;
        }

        var length = Math.Min(value.Length, context.Length);
        var index = 0;
        while (index < length && char.ToUpperInvariant(value[index]) == char.ToUpperInvariant(context[index]))
        {
            index++;
        }

        return index;
    }

    private static string GetEnumMemberForValue(JsonElement schema, string value)
    {
        var index = 0;
        foreach (var item in schema.GetProperty("enum").EnumerateArray())
        {
            var itemValue = item.ValueKind == JsonValueKind.String ? item.GetString() ?? string.Empty : item.GetRawText();
            if (itemValue == value)
            {
                return Naming.EnumMember(itemValue, index);
            }

            index++;
        }

        return Naming.EnumMember(value, index);
    }

    private static string MakeNullable(string type)
    {
        return type.EndsWith("?", StringComparison.Ordinal) ? type : $"{type}?";
    }

    private static string NormalizeNumber(string value, string type)
    {
        return type switch
        {
            "long" => value.Contains('.', StringComparison.Ordinal) ? decimal.Parse(value, CultureInfo.InvariantCulture).ToString("0", CultureInfo.InvariantCulture) + "L" : value + "L",
            "float" => value + "F",
            "decimal" => value + "M",
            _ => value.Contains('.', StringComparison.Ordinal) ? value + "D" : value
        };
    }

    private static string Escape(string value)
    {
        return value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal).Replace("\r", "\\r", StringComparison.Ordinal).Replace("\n", "\\n", StringComparison.Ordinal);
    }

    private sealed record Operation(string ClientName, string Method, string Path, string OperationId, string MethodName, IReadOnlyList<Parameter> Parameters, RequestBody? RequestBody, Response Response);
    private sealed record Parameter(string JsonName, string Name, string Location, string Type, bool Required, string? DefaultValue);
    private sealed record RequestBody(string Type, bool Required, string Kind);
    private sealed record Response(string? Type);
    private readonly record struct ResolvedSchema(JsonElement Schema, bool Nullable);

}

internal static partial class Naming
{
    private static readonly HashSet<string> Keywords = new(StringComparer.Ordinal)
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
    };

    public static string TypeName(string value)
    {
        if (!Separators().IsMatch(value))
        {
            return EnsureIdentifier(value);
        }

        return PascalCase(value);
    }

    public static string PropertyName(string value) => PascalCase(value);
    public static string MethodName(string value) => PascalCase(value);
    public static string ParameterName(string value)
    {
        var name = LowerFirst(PascalCase(value));
        return Keywords.Contains(name) ? name + "Value" : name;
    }

    public static string EnumMember(string value, int index)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "Empty";
        }

        var result = PascalCase(value);
        return string.IsNullOrEmpty(result) ? $"Value{index}" : result;
    }

    public static string HttpMethod(string value)
    {
        return value.ToUpperInvariant() switch
        {
            "GET" => "Get",
            "POST" => "Post",
            "PUT" => "Put",
            "PATCH" => "Patch",
            "DELETE" => "Delete",
            "HEAD" => "Head",
            "OPTIONS" => "Options",
            "TRACE" => "Trace",
            _ => throw new InvalidOperationException($"Unsupported HTTP method {value}.")
        };
    }

    public static string LowerFirst(string value)
    {
        return string.IsNullOrEmpty(value) ? value : char.ToLowerInvariant(value[0]) + value[1..];
    }

    private static string PascalCase(string value)
    {
        if (!Separators().IsMatch(value))
        {
            return EnsureIdentifier(char.ToUpperInvariant(value[0]) + value[1..]);
        }

        var parts = Separators().Split(value).Where(part => part.Length > 0);
        var builder = new StringBuilder();
        foreach (var part in parts)
        {
            builder.Append(char.ToUpperInvariant(part[0]));
            if (part.Length > 1)
            {
                builder.Append(part[1..].ToLowerInvariant());
            }
        }

        return EnsureIdentifier(builder.ToString());
    }

    private static string EnsureIdentifier(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "Value";
        }

        var result = char.IsDigit(value[0]) ? "Value" + value : value;
        return Keywords.Contains(result) ? result + "Value" : result;
    }

    [GeneratedRegex("[^A-Za-z0-9]+")]
    private static partial Regex Separators();
}
