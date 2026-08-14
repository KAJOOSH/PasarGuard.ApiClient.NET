using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record CoreResponse
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("config")]
    public required IReadOnlyDictionary<string, JsonElement> Config { get; init; }

    [JsonPropertyName("type")]
    public CoreType? Type { get; init; }

    [JsonPropertyName("exclude_inbound_tags")]
    public required IReadOnlyList<string> ExcludeInboundTags { get; init; }

    [JsonPropertyName("fallbacks_inbound_tags")]
    public required IReadOnlyList<string> FallbacksInboundTags { get; init; }

    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }
}
