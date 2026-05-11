
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Serialization;

public static class PasarGuardJsonSerializerOptions
{
    public static JsonSerializerOptions Default { get; } = Create();

    private static JsonSerializerOptions Create()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        return options;
    }
}
