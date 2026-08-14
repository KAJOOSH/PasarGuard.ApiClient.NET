using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeUsageStat
{
    [JsonPropertyName("period_start")]
    public required DateTimeOffset PeriodStart { get; init; }

    [JsonPropertyName("uplink")]
    public required long Uplink { get; init; }

    [JsonPropertyName("downlink")]
    public required long Downlink { get; init; }
}
