using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskXicmpSettings
{
    [JsonPropertyName("dgram")]
    public bool? Dgram { get; init; }

    [JsonPropertyName("ips")]
    public IReadOnlyList<string>? Ips { get; init; }

    [JsonPropertyName("listenIp")]
    public string? ListenIp { get; init; }

    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
