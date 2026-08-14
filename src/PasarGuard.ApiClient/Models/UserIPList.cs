using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserIPList
{
    [JsonPropertyName("ips")]
    public required IReadOnlyDictionary<string, long> Ips { get; init; }
}
