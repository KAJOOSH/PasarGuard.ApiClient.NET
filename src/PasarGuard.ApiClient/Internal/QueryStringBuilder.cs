
using System.Collections;

namespace PasarGuard.ApiClient.Internal;

internal sealed class QueryStringBuilder
{
    private readonly List<KeyValuePair<string, string>> values = new();

    public QueryStringBuilder Add(string name, object? value)
    {
        if (value is null)
        {
            return this;
        }

        if (value is string or Enum or DateTime or DateTimeOffset or DateOnly)
        {
            values.Add(new KeyValuePair<string, string>(name, ValueFormatter.Format(value)));
            return this;
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

            return this;
        }

        values.Add(new KeyValuePair<string, string>(name, ValueFormatter.Format(value)));
        return this;
    }

    public string Build(string path)
    {
        if (values.Count == 0)
        {
            return path;
        }

        var query = string.Join("&", values.Select(item => $"{Uri.EscapeDataString(item.Key)}={Uri.EscapeDataString(item.Value)}"));
        return path.Contains('?', StringComparison.Ordinal) ? $"{path}&{query}" : $"{path}?{query}";
    }
}
