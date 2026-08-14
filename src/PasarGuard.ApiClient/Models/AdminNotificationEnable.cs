using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminNotificationEnable
{
    [JsonPropertyName("create")]
    public bool Create { get; init; } = true;

    [JsonPropertyName("modify")]
    public bool Modify { get; init; } = true;

    [JsonPropertyName("delete")]
    public bool Delete { get; init; } = true;

    [JsonPropertyName("reset_usage")]
    public bool ResetUsage { get; init; } = true;

    [JsonPropertyName("login")]
    public bool Login { get; init; } = true;

    [JsonPropertyName("usage_limit_warning")]
    public bool UsageLimitWarning { get; init; } = true;

    [JsonPropertyName("usage_limit_warning_percentages")]
    public IReadOnlyList<long>? UsageLimitWarningPercentages { get; init; }
}
