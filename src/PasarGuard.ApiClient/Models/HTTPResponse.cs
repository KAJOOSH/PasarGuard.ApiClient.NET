using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record HTTPResponse
{
    [JsonPropertyName(@"version")]
    public string Version { get; init; } = @"1.1";

    [JsonPropertyName(@"headers")]
    public Dictionary<string, List<string>>? Headers { get; init; }

    [JsonPropertyName(@"status")]
    public string Status { get; init; } = @"200";

    [JsonPropertyName(@"reason")]
    public string Reason { get; init; } = @"OK";
}
