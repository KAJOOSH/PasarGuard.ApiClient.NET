using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record APIKeysResponse
{
    [JsonPropertyName("api_keys")]
    public required IReadOnlyList<APIKeyResponse> ApiKeys { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
