using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CoreResponseList
{
    [JsonPropertyName(@"count")]
    public required long Count { get; init; }

    [JsonPropertyName(@"cores")]
    public List<CoreResponse> Cores { get; init; } = new();
}
