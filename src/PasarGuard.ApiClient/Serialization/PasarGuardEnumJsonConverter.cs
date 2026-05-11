
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Serialization;

public sealed class PasarGuardEnumJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    private static readonly Dictionary<string, TEnum> FromString = BuildFromString();
    private static readonly Dictionary<TEnum, string> ToStringMap = BuildToString();

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (value is not null && FromString.TryGetValue(value, out var enumValue))
            {
                return enumValue;
            }
        }

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var number))
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), number);
        }

        throw new JsonException($"Unable to convert value to enum {typeof(TEnum).Name}.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (ToStringMap.TryGetValue(value, out var serializedValue))
        {
            writer.WriteStringValue(serializedValue);
            return;
        }

        writer.WriteStringValue(value.ToString());
    }

    private static Dictionary<string, TEnum> BuildFromString()
    {
        return Enum.GetValues<TEnum>().ToDictionary(GetSerializedName, value => value, StringComparer.OrdinalIgnoreCase);
    }

    private static Dictionary<TEnum, string> BuildToString()
    {
        return Enum.GetValues<TEnum>().ToDictionary(value => value, GetSerializedName);
    }

    private static string GetSerializedName(TEnum value)
    {
        var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();
        return member?.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
    }
}
