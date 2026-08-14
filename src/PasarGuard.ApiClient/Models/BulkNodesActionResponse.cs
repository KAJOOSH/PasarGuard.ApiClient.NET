using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkNodesActionResponse
{
    [JsonPropertyName("nodes")]
    public required IReadOnlyList<string> Nodes { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
