using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record SubscriptionUserResponse
{
    [JsonPropertyName(@"proxy_settings")]
    public ProxyTableOutput? ProxySettings { get; init; }

    [JsonPropertyName(@"expire")]
    public object? Expire { get; init; }

    [JsonPropertyName(@"data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName(@"data_limit_reset_strategy")]
    public DataLimitResetStrategy? DataLimitResetStrategy { get; init; }

    [JsonPropertyName(@"on_hold_expire_duration")]
    public long? OnHoldExpireDuration { get; init; }

    [JsonPropertyName(@"on_hold_timeout")]
    public object? OnHoldTimeout { get; init; }

    [JsonPropertyName(@"group_ids")]
    public List<long>? GroupIds { get; init; }

    [JsonPropertyName(@"next_plan")]
    public NextPlanModel? NextPlan { get; init; }

    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"username")]
    public required string Username { get; init; }

    [JsonPropertyName(@"status")]
    public required UserStatus Status { get; init; }

    [JsonPropertyName(@"used_traffic")]
    public required long UsedTraffic { get; init; }

    [JsonPropertyName(@"lifetime_used_traffic")]
    public long LifetimeUsedTraffic { get; init; } = 0L;

    [JsonPropertyName(@"created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName(@"edit_at")]
    public DateTimeOffset? EditAt { get; init; }

    [JsonPropertyName(@"online_at")]
    public DateTimeOffset? OnlineAt { get; init; }
}
