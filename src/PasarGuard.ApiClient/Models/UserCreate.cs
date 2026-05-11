using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserCreate
{
    [JsonPropertyName(@"proxy_settings")]
    public ProxyTableInput? ProxySettings { get; init; }

    [JsonPropertyName(@"expire")]
    public object? Expire { get; init; }

    [JsonPropertyName(@"data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName(@"data_limit_reset_strategy")]
    public DataLimitResetStrategy? DataLimitResetStrategy { get; init; }

    [JsonPropertyName(@"note")]
    public string? Note { get; init; }

    [JsonPropertyName(@"on_hold_expire_duration")]
    public long? OnHoldExpireDuration { get; init; }

    [JsonPropertyName(@"on_hold_timeout")]
    public object? OnHoldTimeout { get; init; }

    [JsonPropertyName(@"group_ids")]
    public List<long>? GroupIds { get; init; }

    [JsonPropertyName(@"auto_delete_in_days")]
    public long? AutoDeleteInDays { get; init; }

    [JsonPropertyName(@"next_plan")]
    public NextPlanModel? NextPlan { get; init; }

    [JsonPropertyName(@"username")]
    public required string Username { get; init; }

    [JsonPropertyName(@"status")]
    public UserStatus? Status { get; init; }
}
