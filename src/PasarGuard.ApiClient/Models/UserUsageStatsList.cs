using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserUsageStatsList
{
    [JsonPropertyName(@"period")]
    public Period? Period { get; init; }

    [JsonPropertyName(@"start")]
    public required DateTimeOffset Start { get; init; }

    [JsonPropertyName(@"end")]
    public required DateTimeOffset End { get; init; }

    [JsonPropertyName(@"stats")]
    public required Dictionary<string, List<UserUsageStat>> Stats { get; init; }
}
