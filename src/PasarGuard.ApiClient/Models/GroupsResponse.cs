using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record GroupsResponse
{
    [JsonPropertyName("groups")]
    public required IReadOnlyList<GroupResponse> Groups { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
