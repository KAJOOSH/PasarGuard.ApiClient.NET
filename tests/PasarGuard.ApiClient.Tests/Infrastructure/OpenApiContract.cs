using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Tests.Infrastructure;

internal static partial class OpenApiContract
{
    private static readonly JsonDocument Specification = JsonDocument.Parse(
        File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "openapi.json")));

    private static readonly HashSet<string> HttpMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "get", "post", "put", "patch", "delete", "head", "options", "trace"
    };

    private static readonly IReadOnlyList<OperationContract> OperationItems = ReadOperations();
    private static readonly IReadOnlyDictionary<string, JsonElement> SchemaItems = Specification.RootElement
        .GetProperty("components")
        .GetProperty("schemas")
        .EnumerateObject()
        .ToDictionary(item => item.Name, item => item.Value, StringComparer.Ordinal);

    public static IReadOnlyList<OperationContract> Operations => OperationItems;
    public static IReadOnlyDictionary<string, JsonElement> Schemas => SchemaItems;

    public static JsonElement ResolveReference(JsonElement schema)
    {
        if (!schema.TryGetProperty("$ref", out var reference))
        {
            return schema;
        }

        var schemaName = reference.GetString()!.Split('/').Last();
        return Schemas[schemaName];
    }

    public static IReadOnlyList<JsonElement> GetParameters(OperationContract operation)
    {
        var parameters = new List<JsonElement>();
        var pathItem = Specification.RootElement.GetProperty("paths").GetProperty(operation.Path);
        if (pathItem.TryGetProperty("parameters", out var pathParameters))
        {
            parameters.AddRange(pathParameters.EnumerateArray());
        }

        if (operation.Definition.TryGetProperty("parameters", out var operationParameters))
        {
            parameters.AddRange(operationParameters.EnumerateArray());
        }

        return parameters
            .GroupBy(item => $"{item.GetProperty("in").GetString()}:{item.GetProperty("name").GetString()}", StringComparer.Ordinal)
            .Select(group => group.Last())
            .ToArray();
    }

    public static Type MapSchemaType(JsonElement schema, string? contextName = null)
    {
        var normalized = NormalizeSchema(schema);
        schema = normalized.Schema;

        if (schema.TryGetProperty("$ref", out var reference))
        {
            return GetModelType(reference.GetString()!.Split('/').Last());
        }

        if (schema.TryGetProperty("enum", out _))
        {
            return FindMatchingEnumType(schema, contextName) ?? typeof(string);
        }

        var schemaType = schema.TryGetProperty("type", out var typeElement) ? typeElement.GetString() : null;
        return schemaType switch
        {
            "string" when schema.TryGetProperty("format", out var format) && format.GetString() == "date-time" => typeof(DateTimeOffset),
            "string" when schema.TryGetProperty("format", out var format) && format.GetString() == "date" => typeof(DateOnly),
            "string" => typeof(string),
            "integer" when schema.TryGetProperty("format", out var format) && format.GetString() == "int32" => typeof(int),
            "integer" => typeof(long),
            "number" when schema.TryGetProperty("format", out var format) && format.GetString() == "float" => typeof(float),
            "number" when schema.TryGetProperty("format", out var format) && format.GetString() == "decimal" => typeof(decimal),
            "number" => typeof(double),
            "boolean" => typeof(bool),
            "array" => typeof(IReadOnlyList<>).MakeGenericType(MapSchemaType(schema.GetProperty("items"))),
            "object" when schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.Object => typeof(IReadOnlyDictionary<,>).MakeGenericType(typeof(string), MapSchemaType(additional)),
            "object" when schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.True => typeof(IReadOnlyDictionary<,>).MakeGenericType(typeof(string), typeof(JsonElement)),
            _ => typeof(JsonElement)
        };
    }

    public static NormalizedSchema NormalizeSchema(JsonElement schema)
    {
        if (!schema.TryGetProperty("anyOf", out var anyOf))
        {
            return new NormalizedSchema(schema, false);
        }

        var candidates = anyOf.EnumerateArray()
            .Where(item => !item.TryGetProperty("type", out var type) || type.GetString() != "null")
            .ToArray();
        var nullable = candidates.Length != anyOf.GetArrayLength();
        return candidates.Length == 1
            ? new NormalizedSchema(candidates[0], nullable)
            : new NormalizedSchema(schema, nullable);
    }

    public static Type GetModelType(string schemaName)
    {
        var typeName = GetTypeName(schemaName);
        return typeof(AdminStatus).Assembly.GetType($"PasarGuard.ApiClient.Models.{typeName}", throwOnError: true)!;
    }

    public static string GetParameterName(string jsonName)
    {
        var name = LowerFirst(GetPascalName(jsonName));
        return name switch
        {
            "abstract" or "as" or "base" or "bool" or "break" or "byte" or "case" or "catch" or "char" or "checked" or "class" or "const" or "continue" or "decimal" or "default" or "delegate" or "do" or "double" or "else" or "enum" or "event" or "explicit" or "extern" or "false" or "finally" or "fixed" or "float" or "for" or "foreach" or "goto" or "if" or "implicit" or "in" or "int" or "interface" or "internal" or "is" or "lock" or "long" or "namespace" or "new" or "null" or "object" or "operator" or "out" or "override" or "params" or "private" or "protected" or "public" or "readonly" or "ref" or "return" or "sbyte" or "sealed" or "short" or "sizeof" or "stackalloc" or "static" or "string" or "struct" or "switch" or "this" or "throw" or "true" or "try" or "typeof" or "uint" or "ulong" or "unchecked" or "unsafe" or "ushort" or "using" or "virtual" or "void" or "volatile" or "while" => name + "Value",
            _ => name
        };
    }

    public static string GetTypeName(string schemaName)
    {
        return Separators().IsMatch(schemaName) ? GetPascalName(schemaName) : EnsureIdentifier(schemaName);
    }

    private static IReadOnlyList<OperationContract> ReadOperations()
    {
        var operations = new List<OperationContract>();
        foreach (var path in Specification.RootElement.GetProperty("paths").EnumerateObject())
        {
            foreach (var operation in path.Value.EnumerateObject().Where(item => HttpMethods.Contains(item.Name)))
            {
                operations.Add(new OperationContract(
                    operation.Value.GetProperty("operationId").GetString()!,
                    operation.Name.ToUpperInvariant(),
                    path.Name,
                    operation.Value));
            }
        }

        return operations.OrderBy(item => item.OperationId, StringComparer.Ordinal).ToArray();
    }

    private static Type? FindMatchingEnumType(JsonElement schema, string? contextName)
    {
        var expected = schema.GetProperty("enum").EnumerateArray().Select(GetWireValue).ToHashSet(StringComparer.Ordinal);
        var match = Schemas
            .Where(item => item.Value.TryGetProperty("enum", out var values) && expected.IsSubsetOf(values.EnumerateArray().Select(GetWireValue)))
            .OrderByDescending(item => SharedPrefixLength(GetTypeName(item.Key), contextName))
            .ThenBy(item => item.Value.GetProperty("enum").GetArrayLength())
            .ThenBy(item => item.Key, StringComparer.Ordinal)
            .Select(item => item.Key)
            .FirstOrDefault();
        return match is null ? null : GetModelType(match);
    }

    private static string GetWireValue(JsonElement value)
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

    private static string GetPascalName(string value)
    {
        if (!Separators().IsMatch(value))
        {
            return EnsureIdentifier(char.ToUpperInvariant(value[0]) + value[1..]);
        }

        var result = string.Concat(Separators().Split(value)
            .Where(part => part.Length > 0)
            .Select(part => char.ToUpperInvariant(part[0]) + part[1..].ToLowerInvariant()));
        return EnsureIdentifier(result);
    }

    private static string LowerFirst(string value)
    {
        return char.ToLowerInvariant(value[0]) + value[1..];
    }

    private static string EnsureIdentifier(string value)
    {
        return char.IsDigit(value[0]) ? "Value" + value : value;
    }

    [GeneratedRegex("[^A-Za-z0-9]+")]
    private static partial Regex Separators();
}

internal sealed record OperationContract(string OperationId, string Method, string Path, JsonElement Definition)
{
    public override string ToString() => $"{Method} {Path} ({OperationId})";
}

internal readonly record struct NormalizedSchema(JsonElement Schema, bool Nullable);
