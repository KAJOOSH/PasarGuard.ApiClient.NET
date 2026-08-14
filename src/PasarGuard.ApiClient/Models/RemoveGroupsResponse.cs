using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RemoveGroupsResponse
{
    [JsonPropertyName("groups")]
    public required IReadOnlyList<string> Groups { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
