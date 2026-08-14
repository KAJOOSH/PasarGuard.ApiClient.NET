using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeUsageStatsList
{
    [JsonPropertyName("period")]
    public Period? Period { get; init; }

    [JsonPropertyName("start")]
    public required DateTimeOffset Start { get; init; }

    [JsonPropertyName("end")]
    public required DateTimeOffset End { get; init; }

    [JsonPropertyName("stats")]
    public required IReadOnlyDictionary<string, IReadOnlyList<NodeUsageStat>> Stats { get; init; }
}
