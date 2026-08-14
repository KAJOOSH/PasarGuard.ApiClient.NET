using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUserTemplatesActionResponse
{
    [JsonPropertyName("templates")]
    public required IReadOnlyList<string> Templates { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
