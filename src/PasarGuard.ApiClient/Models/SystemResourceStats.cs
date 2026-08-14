using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SystemResourceStats
{
    [JsonPropertyName("version")]
    public required string Version { get; init; }

    [JsonPropertyName("uptime_seconds")]
    public required long UptimeSeconds { get; init; }

    [JsonPropertyName("mem_total")]
    public long? MemTotal { get; init; }

    [JsonPropertyName("mem_used")]
    public long? MemUsed { get; init; }

    [JsonPropertyName("disk_total")]
    public long? DiskTotal { get; init; }

    [JsonPropertyName("disk_used")]
    public long? DiskUsed { get; init; }

    [JsonPropertyName("cpu_cores")]
    public long? CpuCores { get; init; }

    [JsonPropertyName("cpu_usage")]
    public double? CpuUsage { get; init; }
}
