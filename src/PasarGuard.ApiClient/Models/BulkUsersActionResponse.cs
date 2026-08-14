using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUsersActionResponse
{
    [JsonPropertyName("users")]
    public required IReadOnlyList<string> Users { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
