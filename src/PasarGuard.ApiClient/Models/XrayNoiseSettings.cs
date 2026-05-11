using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record XrayNoiseSettings
{
    [JsonPropertyName(@"type")]
    public required string Type { get; init; }

    [JsonPropertyName(@"packet")]
    public required string Packet { get; init; }

    [JsonPropertyName(@"delay")]
    public required string Delay { get; init; }

    [JsonPropertyName(@"apply_to")]
    public string ApplyTo { get; init; } = @"ip";

    [JsonPropertyName(@"rand_range")]
    public string? RandRange { get; init; }
}
