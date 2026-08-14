using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserCountMetricStatsList
{
    [JsonPropertyName("period")]
    public Period? Period { get; init; }

    [JsonPropertyName("start")]
    public required DateTimeOffset Start { get; init; }

    [JsonPropertyName("end")]
    public required DateTimeOffset End { get; init; }

    [JsonPropertyName("metric")]
    public required UserCountMetric Metric { get; init; }

    [JsonPropertyName("count_during_period")]
    public long CountDuringPeriod { get; init; } = 0L;

    [JsonPropertyName("stats")]
    public required IReadOnlyDictionary<string, IReadOnlyList<UserCountMetricStat>> Stats { get; init; }
}
