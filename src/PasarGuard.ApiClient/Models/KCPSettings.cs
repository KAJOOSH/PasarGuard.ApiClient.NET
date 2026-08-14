using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record KCPSettings
{
    [JsonPropertyName("mtu")]
    public long? Mtu { get; init; }

    [JsonPropertyName("tti")]
    public long? Tti { get; init; }

    [JsonPropertyName("uplink_capacity")]
    public long? UplinkCapacity { get; init; }

    [JsonPropertyName("downlink_capacity")]
    public long? DownlinkCapacity { get; init; }

    [JsonPropertyName("congestion")]
    public bool? Congestion { get; init; }

    [JsonPropertyName("read_buffer_size")]
    public long? ReadBufferSize { get; init; }

    [JsonPropertyName("write_buffer_size")]
    public long? WriteBufferSize { get; init; }
}
