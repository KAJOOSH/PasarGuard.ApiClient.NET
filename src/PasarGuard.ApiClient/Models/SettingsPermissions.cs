using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SettingsPermissions
{
    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }

    [JsonPropertyName("read_general")]
    public JsonElement? ReadGeneral { get; init; }

    [JsonPropertyName("update")]
    public JsonElement? Update { get; init; }
}
