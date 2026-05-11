using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NodeUsageStat
{
    [JsonPropertyName(@"uplink")]
    public required long Uplink { get; init; }

    [JsonPropertyName(@"downlink")]
    public required long Downlink { get; init; }

    [JsonPropertyName(@"period_start")]
    public required DateTimeOffset PeriodStart { get; init; }
}
