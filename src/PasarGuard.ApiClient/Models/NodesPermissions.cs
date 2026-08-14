using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodesPermissions
{
    [JsonPropertyName("create")]
    public JsonElement? Create { get; init; }

    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }

    [JsonPropertyName("read_simple")]
    public JsonElement? ReadSimple { get; init; }

    [JsonPropertyName("update")]
    public JsonElement? Update { get; init; }

    [JsonPropertyName("delete")]
    public JsonElement? Delete { get; init; }

    [JsonPropertyName("reconnect")]
    public JsonElement? Reconnect { get; init; }

    [JsonPropertyName("update_core")]
    public JsonElement? UpdateCore { get; init; }

    [JsonPropertyName("logs")]
    public JsonElement? Logs { get; init; }

    [JsonPropertyName("stats")]
    public JsonElement? Stats { get; init; }
}
