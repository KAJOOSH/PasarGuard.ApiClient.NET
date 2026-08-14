using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RoleLimits
{
    [JsonPropertyName("max_users")]
    public long? MaxUsers { get; init; }

    [JsonPropertyName("data_limit_min")]
    public long? DataLimitMin { get; init; }

    [JsonPropertyName("data_limit_max")]
    public long? DataLimitMax { get; init; }

    [JsonPropertyName("expire_min")]
    public long? ExpireMin { get; init; }

    [JsonPropertyName("expire_max")]
    public long? ExpireMax { get; init; }

    [JsonPropertyName("min_hwid_per_user")]
    public long? MinHwidPerUser { get; init; }

    [JsonPropertyName("max_hwid_per_user")]
    public long? MaxHwidPerUser { get; init; }

    [JsonPropertyName("on_hold_timeout_min")]
    public long? OnHoldTimeoutMin { get; init; }

    [JsonPropertyName("on_hold_timeout_max")]
    public long? OnHoldTimeoutMax { get; init; }
}
