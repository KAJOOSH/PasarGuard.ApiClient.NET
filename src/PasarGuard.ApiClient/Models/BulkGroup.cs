using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkGroup
{
    [JsonPropertyName(@"group_ids")]
    public required List<long> GroupIds { get; init; }

    [JsonPropertyName(@"has_group_ids")]
    public List<long>? HasGroupIds { get; init; }

    [JsonPropertyName(@"admins")]
    public List<long>? Admins { get; init; }

    [JsonPropertyName(@"users")]
    public List<long>? Users { get; init; }

    [JsonPropertyName(@"dry_run")]
    public bool DryRun { get; init; } = false;
}
