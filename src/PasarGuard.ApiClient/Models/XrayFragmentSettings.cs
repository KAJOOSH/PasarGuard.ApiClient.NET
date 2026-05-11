using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record XrayFragmentSettings
{
    [JsonPropertyName(@"packets")]
    public required string Packets { get; init; }

    [JsonPropertyName(@"length")]
    public required string Length { get; init; }

    [JsonPropertyName(@"interval")]
    public required string Interval { get; init; }
}
