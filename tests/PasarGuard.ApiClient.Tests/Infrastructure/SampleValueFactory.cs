using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Tests.Infrastructure;

internal static class SampleValueFactory
{
    private static readonly DateTimeOffset SampleDateTime = new(2026, 8, 14, 10, 11, 12, TimeSpan.Zero);

    public static object? CreateParameter(Type type, string location)
    {
        var effectiveType = Nullable.GetUnderlyingType(type) ?? type;
        if (effectiveType == typeof(string))
        {
            return location == "path" ? "segment/value" : location == "header" ? "header-value" : "query value";
        }

        return Create(type);
    }

    public static object? Create(Type type, int depth = 0, ISet<Type>? ancestry = null)
    {
        var nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType is not null)
        {
            return Create(nullableType, depth, ancestry);
        }

        if (type == typeof(string))
        {
            return "sample value";
        }

        if (type == typeof(bool))
        {
            return true;
        }

        if (type == typeof(byte))
        {
            return (byte)17;
        }

        if (type == typeof(short))
        {
            return (short)17;
        }

        if (type == typeof(int))
        {
            return 17;
        }

        if (type == typeof(long))
        {
            return 17L;
        }

        if (type == typeof(float))
        {
            return 17.5F;
        }

        if (type == typeof(double))
        {
            return 17.5D;
        }

        if (type == typeof(decimal))
        {
            return 17.5M;
        }

        if (type == typeof(DateTimeOffset))
        {
            return SampleDateTime;
        }

        if (type == typeof(DateTime))
        {
            return SampleDateTime.UtcDateTime;
        }

        if (type == typeof(DateOnly))
        {
            return DateOnly.FromDateTime(SampleDateTime.UtcDateTime);
        }

        if (type == typeof(JsonElement))
        {
            return JsonSerializer.SerializeToElement("sample");
        }

        if (type.IsEnum)
        {
            return Enum.GetValues(type).GetValue(0);
        }

        if (TryGetGenericInterface(type, typeof(IReadOnlyList<>), out var listInterface))
        {
            var itemType = listInterface.GetGenericArguments()[0];
            var array = Array.CreateInstance(itemType, 2);
            array.SetValue(Create(itemType, depth + 1, ancestry), 0);
            array.SetValue(Create(itemType, depth + 1, ancestry), 1);
            return array;
        }

        if (TryGetGenericInterface(type, typeof(IReadOnlyDictionary<,>), out var dictionaryInterface))
        {
            var arguments = dictionaryInterface.GetGenericArguments();
            return Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(arguments));
        }

        if (depth >= 5)
        {
            return null;
        }

        ancestry ??= new HashSet<Type>();
        if (!ancestry.Add(type))
        {
            return null;
        }

        var instance = Activator.CreateInstance(type);
        if (instance is null)
        {
            ancestry.Remove(type);
            return null;
        }

        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(item => item.SetMethod is not null))
        {
            object? value;
            if (property.GetCustomAttribute<JsonExtensionDataAttribute>() is not null)
            {
                value = CreateEmptyDictionary(property.PropertyType);
            }
            else
            {
                value = Create(property.PropertyType, depth + 1, ancestry);
            }

            if (value is not null || !property.PropertyType.IsValueType || Nullable.GetUnderlyingType(property.PropertyType) is not null)
            {
                property.SetValue(instance, value);
            }
        }

        ancestry.Remove(type);
        return instance;
    }

    private static object? CreateEmptyDictionary(Type type)
    {
        return TryGetGenericInterface(type, typeof(IReadOnlyDictionary<,>), out var dictionaryInterface)
            ? Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(dictionaryInterface.GetGenericArguments()))
            : null;
    }

    private static bool TryGetGenericInterface(Type type, Type genericDefinition, out Type match)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == genericDefinition)
        {
            match = type;
            return true;
        }

        match = type.GetInterfaces().FirstOrDefault(item => item.IsGenericType && item.GetGenericTypeDefinition() == genericDefinition)!;
        return match is not null;
    }
}
