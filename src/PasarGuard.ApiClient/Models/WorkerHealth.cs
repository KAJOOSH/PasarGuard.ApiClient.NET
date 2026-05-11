using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WorkerHealth
{
    [JsonPropertyName(@"status")]
    public required string Status { get; init; }

    [JsonPropertyName(@"response_time_ms")]
    public long? ResponseTimeMs { get; init; }

    [JsonPropertyName(@"error")]
    public string? Error { get; init; }
}
