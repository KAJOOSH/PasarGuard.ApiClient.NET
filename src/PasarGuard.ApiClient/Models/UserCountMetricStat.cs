using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserCountMetricStat
{
    [JsonPropertyName("period_start")]
    public required DateTimeOffset PeriodStart { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
