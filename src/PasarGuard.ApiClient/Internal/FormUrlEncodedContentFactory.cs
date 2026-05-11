
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Internal;

internal static class FormUrlEncodedContentFactory
{
    public static FormUrlEncodedContent Create(object body)
    {
        var values = new List<KeyValuePair<string, string>>();
        var properties = body.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

        foreach (var property in properties)
        {
            var value = property.GetValue(body);
            if (value is null)
            {
                continue;
            }

            var name = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;

            if (value is string or Enum or DateTime or DateTimeOffset or DateOnly)
            {
                values.Add(new KeyValuePair<string, string>(name, ValueFormatter.Format(value)));
                continue;
            }

            if (value is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item is not null)
                    {
                        values.Add(new KeyValuePair<string, string>(name, ValueFormatter.Format(item)));
                    }
                }

                continue;
            }

            values.Add(new KeyValuePair<string, string>(name, ValueFormatter.Format(value)));
        }

        return new FormUrlEncodedContent(values);
    }
}
