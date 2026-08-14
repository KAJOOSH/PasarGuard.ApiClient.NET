using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RemoveCoresResponse
{
    [JsonPropertyName("cores")]
    public required IReadOnlyList<string> Cores { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
