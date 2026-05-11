using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkUsersProxy
{
    [JsonPropertyName(@"dry_run")]
    public bool DryRun { get; init; } = false;

    [JsonPropertyName(@"group_ids")]
    public List<long>? GroupIds { get; init; }

    [JsonPropertyName(@"admins")]
    public List<long>? Admins { get; init; }

    [JsonPropertyName(@"users")]
    public List<long>? Users { get; init; }

    [JsonPropertyName(@"status")]
    public List<UserStatus>? Status { get; init; }

    [JsonPropertyName(@"expire_after")]
    public DateTimeOffset? ExpireAfter { get; init; }

    [JsonPropertyName(@"expire_before")]
    public DateTimeOffset? ExpireBefore { get; init; }

    [JsonPropertyName(@"flow")]
    public XTLSFlows? Flow { get; init; }

    [JsonPropertyName(@"method")]
    public ShadowsocksMethods? Method { get; init; }
}
