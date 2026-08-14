using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkAdminsActionResponse
{
    [JsonPropertyName("admins")]
    public required IReadOnlyList<string> Admins { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
