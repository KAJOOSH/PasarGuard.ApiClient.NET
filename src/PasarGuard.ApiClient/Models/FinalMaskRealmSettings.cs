using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskRealmSettings
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("stunServers")]
    public IReadOnlyList<string>? StunServers { get; init; }

    [JsonPropertyName("tlsConfig")]
    public IReadOnlyDictionary<string, JsonElement>? TlsConfig { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
