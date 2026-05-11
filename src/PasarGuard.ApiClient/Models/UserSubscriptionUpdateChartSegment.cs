using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserSubscriptionUpdateChartSegment
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"count")]
    public required long Count { get; init; }

    [JsonPropertyName(@"percentage")]
    public required double Percentage { get; init; }
}
