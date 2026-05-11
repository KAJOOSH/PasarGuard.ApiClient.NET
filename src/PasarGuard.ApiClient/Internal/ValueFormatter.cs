
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace PasarGuard.ApiClient.Internal;

internal static class ValueFormatter
{
    public static string? FormatNullable(object? value)
    {
        return value is null ? null : Format(value);
    }

    public static string Format(object value)
    {
        return value switch
        {
            string text => text,
            bool boolean => boolean ? "true" : "false",
            DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("O", CultureInfo.InvariantCulture),
            DateTime dateTime => dateTime.ToString("O", CultureInfo.InvariantCulture),
            DateOnly dateOnly => dateOnly.ToString("O", CultureInfo.InvariantCulture),
            Enum enumValue => GetEnumValue(enumValue),
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };
    }

    private static string GetEnumValue(Enum value)
    {
        var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        return member?.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? value.ToString();
    }
}
