using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserTemplateResponse
{
    [JsonPropertyName(@"name")]
    public string? Name { get; init; }

    [JsonPropertyName(@"data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName(@"expire_duration")]
    public long? ExpireDuration { get; init; }

    [JsonPropertyName(@"username_prefix")]
    public string? UsernamePrefix { get; init; }

    [JsonPropertyName(@"username_suffix")]
    public string? UsernameSuffix { get; init; }

    [JsonPropertyName(@"group_ids")]
    public required List<long> GroupIds { get; init; }

    [JsonPropertyName(@"extra_settings")]
    public ExtraSettings? ExtraSettings { get; init; }

    [JsonPropertyName(@"status")]
    public UserStatusCreate? Status { get; init; }

    [JsonPropertyName(@"reset_usages")]
    public bool? ResetUsages { get; init; }

    [JsonPropertyName(@"on_hold_timeout")]
    public long? OnHoldTimeout { get; init; }

    [JsonPropertyName(@"data_limit_reset_strategy")]
    public DataLimitResetStrategy DataLimitResetStrategy { get; init; } = DataLimitResetStrategy.NoReset;

    [JsonPropertyName(@"is_disabled")]
    public bool? IsDisabled { get; init; }

    [JsonPropertyName(@"id")]
    public required long Id { get; init; }
}
