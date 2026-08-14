using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record WireGuardHostOverrides
{
    [JsonPropertyName("allowed_ips")]
    public IReadOnlyList<string>? AllowedIps { get; init; }

    [JsonPropertyName("mtu")]
    public long? Mtu { get; init; }

    [JsonPropertyName("reserved")]
    public string? Reserved { get; init; }

    [JsonPropertyName("keepalive_seconds")]
    public long? KeepaliveSeconds { get; init; }

    [JsonPropertyName("dns")]
    public IReadOnlyList<string>? Dns { get; init; }
}
