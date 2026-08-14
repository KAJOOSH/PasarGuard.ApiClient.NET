using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserSubscriptionUpdateChart
{
    [JsonPropertyName("period")]
    public Period? Period { get; init; }

    [JsonPropertyName("start")]
    public required DateTimeOffset Start { get; init; }

    [JsonPropertyName("end")]
    public required DateTimeOffset End { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }

    [JsonPropertyName("segments")]
    public IReadOnlyList<UserSubscriptionUpdateChartSegment>? Segments { get; init; }

    [JsonPropertyName("stats")]
    public IReadOnlyList<UserSubscriptionUpdateChartStat>? Stats { get; init; }
}
