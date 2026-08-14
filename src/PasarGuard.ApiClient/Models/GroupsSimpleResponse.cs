using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record GroupsSimpleResponse
{
    [JsonPropertyName("groups")]
    public required IReadOnlyList<GroupSimple> Groups { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
