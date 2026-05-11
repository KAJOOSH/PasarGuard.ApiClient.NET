using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NodeUsageStatsList
{
    [JsonPropertyName(@"period")]
    public Period? Period { get; init; }

    [JsonPropertyName(@"start")]
    public required DateTimeOffset Start { get; init; }

    [JsonPropertyName(@"end")]
    public required DateTimeOffset End { get; init; }

    [JsonPropertyName(@"stats")]
    public required Dictionary<string, List<NodeUsageStat>> Stats { get; init; }
}
