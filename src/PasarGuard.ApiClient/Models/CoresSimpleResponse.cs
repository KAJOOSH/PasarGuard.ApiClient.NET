using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CoresSimpleResponse
{
    [JsonPropertyName(@"cores")]
    public required List<CoreSimple> Cores { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }
}
