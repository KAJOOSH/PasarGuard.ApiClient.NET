using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record WireGuardSettings
{
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; init; }

    [JsonPropertyName("public_key")]
    public string? PublicKey { get; init; }

    [JsonPropertyName("peer_ips")]
    public IReadOnlyList<string>? PeerIps { get; init; }
}
