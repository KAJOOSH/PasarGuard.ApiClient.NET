using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserIPListAll
{
    [JsonPropertyName("nodes")]
    public required IReadOnlyDictionary<string, UserIPList> Nodes { get; init; }
}
