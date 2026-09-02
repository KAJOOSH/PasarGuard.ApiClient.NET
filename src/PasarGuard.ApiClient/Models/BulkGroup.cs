using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkGroup
{
    [JsonPropertyName("group_ids")]
    public required IReadOnlyList<long> GroupIds { get; init; }

    [JsonPropertyName("has_group_ids")]
    public IReadOnlyList<long>? HasGroupIds { get; init; }

    [JsonPropertyName("has_no_group")]
    public bool HasNoGroup { get; init; } = false;

    [JsonPropertyName("admins")]
    public IReadOnlyList<long>? Admins { get; init; }

    [JsonPropertyName("users")]
    public IReadOnlyList<long>? Users { get; init; }

    [JsonPropertyName("dry_run")]
    public bool DryRun { get; init; } = false;
}
