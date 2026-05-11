using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserSubscriptionUpdateChart
{
    [JsonPropertyName(@"total")]
    public required long Total { get; init; }

    [JsonPropertyName(@"segments")]
    public List<UserSubscriptionUpdateChartSegment>? Segments { get; init; }
}
