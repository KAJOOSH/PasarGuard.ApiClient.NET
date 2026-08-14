using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record CoreResponseList
{
    [JsonPropertyName("count")]
    public required long Count { get; init; }

    [JsonPropertyName("cores")]
    public IReadOnlyList<CoreResponse> Cores { get; init; } = [];
}
