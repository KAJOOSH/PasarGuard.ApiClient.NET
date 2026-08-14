using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record WireGuardSubnetUsage
{
    [JsonPropertyName("subnet")]
    public required string Subnet { get; init; }

    [JsonPropertyName("interface_tags")]
    public required IReadOnlyList<string> InterfaceTags { get; init; }

    [JsonPropertyName("capacity")]
    public required long Capacity { get; init; }

    [JsonPropertyName("used")]
    public required long Used { get; init; }

    [JsonPropertyName("free")]
    public required long Free { get; init; }

    [JsonPropertyName("free_ips")]
    public required IReadOnlyList<string> FreeIps { get; init; }
}
