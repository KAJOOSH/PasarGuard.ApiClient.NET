using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ClashMuxSettings
{
    [JsonPropertyName("enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName("protocol")]
    public MultiplexProtocol Protocol { get; init; } = MultiplexProtocol.Smux;

    [JsonPropertyName("max_connections")]
    public long? MaxConnections { get; init; }

    [JsonPropertyName("max_streams")]
    public long? MaxStreams { get; init; }

    [JsonPropertyName("min_streams")]
    public long? MinStreams { get; init; }

    [JsonPropertyName("padding")]
    public bool Padding { get; init; } = false;

    [JsonPropertyName("brutal")]
    public Brutal? Brutal { get; init; }

    [JsonPropertyName("statistic")]
    public bool Statistic { get; init; } = false;

    [JsonPropertyName("only_tcp")]
    public bool OnlyTcp { get; init; } = false;
}
