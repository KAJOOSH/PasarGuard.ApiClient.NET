using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CoreResponse
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"config")]
    public required Dictionary<string, object?> Config { get; init; }

    [JsonPropertyName(@"type")]
    public CoreType? Type { get; init; }

    [JsonPropertyName(@"exclude_inbound_tags")]
    public required List<string> ExcludeInboundTags { get; init; }

    [JsonPropertyName(@"fallbacks_inbound_tags")]
    public required List<string> FallbacksInboundTags { get; init; }

    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"created_at")]
    public required DateTimeOffset CreatedAt { get; init; }
}
