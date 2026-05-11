using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record SystemStats
{
    [JsonPropertyName(@"version")]
    public required string Version { get; init; }

    [JsonPropertyName(@"uptime_seconds")]
    public required long UptimeSeconds { get; init; }

    [JsonPropertyName(@"mem_total")]
    public long? MemTotal { get; init; }

    [JsonPropertyName(@"mem_used")]
    public long? MemUsed { get; init; }

    [JsonPropertyName(@"disk_total")]
    public long? DiskTotal { get; init; }

    [JsonPropertyName(@"disk_used")]
    public long? DiskUsed { get; init; }

    [JsonPropertyName(@"cpu_cores")]
    public long? CpuCores { get; init; }

    [JsonPropertyName(@"cpu_usage")]
    public double? CpuUsage { get; init; }

    [JsonPropertyName(@"total_user")]
    public required long TotalUser { get; init; }

    [JsonPropertyName(@"online_users")]
    public required long OnlineUsers { get; init; }

    [JsonPropertyName(@"active_users")]
    public required long ActiveUsers { get; init; }

    [JsonPropertyName(@"on_hold_users")]
    public required long OnHoldUsers { get; init; }

    [JsonPropertyName(@"disabled_users")]
    public required long DisabledUsers { get; init; }

    [JsonPropertyName(@"expired_users")]
    public required long ExpiredUsers { get; init; }

    [JsonPropertyName(@"limited_users")]
    public required long LimitedUsers { get; init; }

    [JsonPropertyName(@"incoming_bandwidth")]
    public required long IncomingBandwidth { get; init; }

    [JsonPropertyName(@"outgoing_bandwidth")]
    public required long OutgoingBandwidth { get; init; }
}
