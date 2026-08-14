using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record CoreCreate
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("config")]
    public required IReadOnlyDictionary<string, JsonElement> Config { get; init; }

    [JsonPropertyName("type")]
    public CoreType? Type { get; init; }

    [JsonPropertyName("exclude_inbound_tags")]
    public IReadOnlyList<JsonElement>? ExcludeInboundTags { get; init; }

    [JsonPropertyName("fallbacks_inbound_tags")]
    public IReadOnlyList<JsonElement>? FallbacksInboundTags { get; init; }
}
