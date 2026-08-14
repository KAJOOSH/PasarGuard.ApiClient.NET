using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeOutboundLatency
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("alive")]
    public required bool Alive { get; init; }

    [JsonPropertyName("delay")]
    public required long Delay { get; init; }

    [JsonPropertyName("link")]
    public required string Link { get; init; }

    [JsonPropertyName("last_seen_time")]
    public required long LastSeenTime { get; init; }

    [JsonPropertyName("last_try_time")]
    public required long LastTryTime { get; init; }

    [JsonPropertyName("source")]
    public required string Source { get; init; }
}
