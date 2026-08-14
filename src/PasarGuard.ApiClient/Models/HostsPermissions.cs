using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HostsPermissions
{
    [JsonPropertyName("create")]
    public JsonElement? Create { get; init; }

    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }

    [JsonPropertyName("update")]
    public JsonElement? Update { get; init; }
}
