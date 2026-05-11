using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserUsageStat
{
    [JsonPropertyName(@"total_traffic")]
    public required long TotalTraffic { get; init; }

    [JsonPropertyName(@"period_start")]
    public required DateTimeOffset PeriodStart { get; init; }
}
