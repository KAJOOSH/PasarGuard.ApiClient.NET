using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserUsageStat
{
    [JsonPropertyName("period_start")]
    public required DateTimeOffset PeriodStart { get; init; }

    [JsonPropertyName("total_traffic")]
    public required long TotalTraffic { get; init; }
}
