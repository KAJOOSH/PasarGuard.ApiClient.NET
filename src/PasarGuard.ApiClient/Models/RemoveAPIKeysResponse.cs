using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RemoveAPIKeysResponse
{
    [JsonPropertyName("api_keys")]
    public required IReadOnlyList<string> ApiKeys { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
