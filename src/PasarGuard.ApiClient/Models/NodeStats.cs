using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeStats
{
    [JsonPropertyName("period_start")]
    public required DateTimeOffset PeriodStart { get; init; }

    [JsonPropertyName("mem_usage_percentage")]
    public required double MemUsagePercentage { get; init; }

    [JsonPropertyName("cpu_usage_percentage")]
    public required double CpuUsagePercentage { get; init; }

    [JsonPropertyName("incoming_bandwidth_speed")]
    public required double IncomingBandwidthSpeed { get; init; }

    [JsonPropertyName("outgoing_bandwidth_speed")]
    public required double OutgoingBandwidthSpeed { get; init; }
}
