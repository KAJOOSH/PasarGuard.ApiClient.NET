using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Tests.Infrastructure;

namespace PasarGuard.ApiClient.Tests;

public sealed class OpenApiModelContractTests
{
    private static readonly NullabilityInfoContext Nullability = new();

    public static IEnumerable<object[]> ComponentSchemas()
    {
        return OpenApiContract.Schemas.Keys.OrderBy(name => name, StringComparer.Ordinal).Select(name => new object[] { name });
    }

    [Theory]
    [MemberData(nameof(ComponentSchemas))]
    public void ModelExactlyMatchesOpenApiSchema(string schemaName)
    {
        var schema = OpenApiContract.Schemas[schemaName];
        var modelType = OpenApiContract.GetModelType(schemaName);

        if (schema.TryGetProperty("enum", out var enumValues))
        {
            AssertEnum(modelType, enumValues);
            return;
        }

        Assert.True(modelType.IsClass, $"{modelType.Name} must be a class.");
        Assert.True(modelType.IsSealed, $"{modelType.Name} must be sealed.");
        AssertObject(modelType, schema);
    }

    private static void AssertEnum(Type modelType, JsonElement enumValues)
    {
        Assert.True(modelType.IsEnum, $"{modelType.Name} must be an enum.");
        Assert.NotNull(modelType.GetCustomAttribute<JsonConverterAttribute>());
        var expected = enumValues.EnumerateArray().Select(GetJsonScalar).ToArray();
        var actual = Enum.GetValues(modelType).Cast<Enum>().Select(GetEnumWireValue).ToArray();
        Assert.Equal(expected, actual);
    }

    private static void AssertObject(Type modelType, JsonElement schema)
    {
        var schemaProperties = schema.TryGetProperty("properties", out var properties)
            ? properties.EnumerateObject().ToDictionary(item => item.Name, item => item.Value, StringComparer.Ordinal)
            : new Dictionary<string, JsonElement>(StringComparer.Ordinal);
        var requiredProperties = schema.TryGetProperty("required", out var required)
            ? required.EnumerateArray().Select(item => item.GetString()!).ToHashSet(StringComparer.Ordinal)
            : new HashSet<string>(StringComparer.Ordinal);
        var modelProperties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var contractProperties = modelProperties
            .Where(property => property.GetCustomAttribute<JsonPropertyNameAttribute>() is not null)
            .ToDictionary(property => property.GetCustomAttribute<JsonPropertyNameAttribute>()!.Name, property => property, StringComparer.Ordinal);

        Assert.Equal(schemaProperties.Keys.OrderBy(name => name, StringComparer.Ordinal), contractProperties.Keys.OrderBy(name => name, StringComparer.Ordinal));
        var instance = Activator.CreateInstance(modelType)!;
        foreach (var item in schemaProperties)
        {
            AssertProperty(modelType, contractProperties[item.Key], item.Key, item.Value, requiredProperties.Contains(item.Key), instance);
        }

        var extensionProperties = modelProperties.Where(property => property.GetCustomAttribute<JsonExtensionDataAttribute>() is not null).ToArray();
        var allowsAdditional = schema.TryGetProperty("additionalProperties", out var additional) && additional.ValueKind == JsonValueKind.True;
        Assert.Equal(allowsAdditional ? 1 : 0, extensionProperties.Length);
    }

    private static void AssertProperty(Type modelType, PropertyInfo property, string jsonName, JsonElement schema, bool required, object instance)
    {
        var normalized = OpenApiContract.NormalizeSchema(schema);
        var expectedType = OpenApiContract.MapSchemaType(schema, modelType.Name);
        var hasDefault = schema.TryGetProperty("default", out var defaultValue);
        var nullable = normalized.Nullable || (!required && !hasDefault) || (hasDefault && defaultValue.ValueKind == JsonValueKind.Null);
        var expectedPropertyType = nullable && expectedType.IsValueType
            ? typeof(Nullable<>).MakeGenericType(expectedType)
            : expectedType;
        Assert.Equal(expectedPropertyType, property.PropertyType);

        var isRequiredMember = property.GetCustomAttribute<RequiredMemberAttribute>() is not null;
        Assert.Equal(required && !hasDefault, isRequiredMember);
        AssertNullability(property, nullable);

        if (hasDefault)
        {
            Assert.Equal(GetExpectedDefault(defaultValue), GetActualDefault(property.GetValue(instance)));
        }

        Assert.Equal(jsonName, property.GetCustomAttribute<JsonPropertyNameAttribute>()!.Name);
    }

    private static void AssertNullability(PropertyInfo property, bool expectedNullable)
    {
        if (Nullable.GetUnderlyingType(property.PropertyType) is not null)
        {
            Assert.True(expectedNullable);
            return;
        }

        if (property.PropertyType.IsValueType)
        {
            Assert.False(expectedNullable);
            return;
        }

        var state = Nullability.Create(property).ReadState;
        Assert.Equal(expectedNullable ? NullabilityState.Nullable : NullabilityState.NotNull, state);
    }

    private static string GetExpectedDefault(JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.Null => "null",
            JsonValueKind.String => "string:" + value.GetString(),
            JsonValueKind.True => "bool:true",
            JsonValueKind.False => "bool:false",
            JsonValueKind.Number => "number:" + decimal.Parse(value.GetRawText(), CultureInfo.InvariantCulture).ToString("G29", CultureInfo.InvariantCulture),
            JsonValueKind.Array => "array:" + value.GetArrayLength().ToString(CultureInfo.InvariantCulture),
            JsonValueKind.Object => "object:" + value.EnumerateObject().Count().ToString(CultureInfo.InvariantCulture),
            _ => value.GetRawText()
        };
    }

    private static string GetActualDefault(object? value)
    {
        return value switch
        {
            null => "null",
            string text => "string:" + text,
            bool boolean => "bool:" + boolean.ToString().ToLowerInvariant(),
            Enum enumValue => "string:" + GetEnumWireValue(enumValue),
            byte or short or int or long or float or double or decimal => "number:" + Convert.ToDecimal(value, CultureInfo.InvariantCulture).ToString("G29", CultureInfo.InvariantCulture),
            IDictionary dictionary => "object:" + dictionary.Count.ToString(CultureInfo.InvariantCulture),
            IEnumerable enumerable => "array:" + enumerable.Cast<object?>().Count().ToString(CultureInfo.InvariantCulture),
            JsonElement element when element.ValueKind == JsonValueKind.Undefined => "undefined",
            JsonElement element => GetExpectedDefault(element),
            _ => value.ToString() ?? string.Empty
        };
    }

    private static string GetEnumWireValue(Enum value)
    {
        return value.GetType().GetMember(value.ToString()).Single().GetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
    }

    private static string GetJsonScalar(JsonElement value)
    {
        return value.ValueKind == JsonValueKind.String ? value.GetString() ?? string.Empty : value.GetRawText();
    }
}
