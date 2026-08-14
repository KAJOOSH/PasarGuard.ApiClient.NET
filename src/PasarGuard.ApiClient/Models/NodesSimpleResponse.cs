using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodesSimpleResponse
{
    [JsonPropertyName("nodes")]
    public required IReadOnlyList<NodeSimple> Nodes { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
