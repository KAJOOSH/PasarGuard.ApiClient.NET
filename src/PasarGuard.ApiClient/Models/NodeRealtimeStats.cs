using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NodeRealtimeStats
{
    [JsonPropertyName(@"mem_total")]
    public required long MemTotal { get; init; }

    [JsonPropertyName(@"mem_used")]
    public required long MemUsed { get; init; }

    [JsonPropertyName(@"cpu_cores")]
    public required long CpuCores { get; init; }

    [JsonPropertyName(@"cpu_usage")]
    public required double CpuUsage { get; init; }

    [JsonPropertyName(@"incoming_bandwidth_speed")]
    public required long IncomingBandwidthSpeed { get; init; }

    [JsonPropertyName(@"outgoing_bandwidth_speed")]
    public required long OutgoingBandwidthSpeed { get; init; }

    [JsonPropertyName(@"uptime")]
    public required long Uptime { get; init; }
}
