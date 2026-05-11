using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserNotificationEnable
{
    [JsonPropertyName(@"create")]
    public bool Create { get; init; } = true;

    [JsonPropertyName(@"modify")]
    public bool Modify { get; init; } = true;

    [JsonPropertyName(@"delete")]
    public bool Delete { get; init; } = true;

    [JsonPropertyName(@"status_change")]
    public bool StatusChange { get; init; } = true;

    [JsonPropertyName(@"reset_data_usage")]
    public bool ResetDataUsage { get; init; } = true;

    [JsonPropertyName(@"data_reset_by_next")]
    public bool DataResetByNext { get; init; } = true;

    [JsonPropertyName(@"subscription_revoked")]
    public bool SubscriptionRevoked { get; init; } = true;
}
