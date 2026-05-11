using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record HTTPRequest
{
    [JsonPropertyName(@"version")]
    public string Version { get; init; } = @"1.1";

    [JsonPropertyName(@"headers")]
    public Dictionary<string, List<string>>? Headers { get; init; }

    [JsonPropertyName(@"method")]
    public string Method { get; init; } = @"GET";
}
