using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NodeSimple
{
    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"status")]
    public required NodeStatus Status { get; init; }
}
