using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CoreSimple
{
    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"type")]
    public CoreType? Type { get; init; }
}
