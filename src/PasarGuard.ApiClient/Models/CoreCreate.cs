using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CoreCreate
{
    [JsonPropertyName(@"name")]
    public string? Name { get; init; }

    [JsonPropertyName(@"config")]
    public required Dictionary<string, object?> Config { get; init; }

    [JsonPropertyName(@"type")]
    public CoreType? Type { get; init; }

    [JsonPropertyName(@"exclude_inbound_tags")]
    public List<JsonElement>? ExcludeInboundTags { get; init; }

    [JsonPropertyName(@"fallbacks_inbound_tags")]
    public List<JsonElement>? FallbacksInboundTags { get; init; }
}
