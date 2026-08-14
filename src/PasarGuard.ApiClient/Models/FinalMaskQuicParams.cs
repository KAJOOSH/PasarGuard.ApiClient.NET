using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskQuicParams
{
    [JsonPropertyName("congestion")]
    public FinalMaskQuicCongestion? Congestion { get; init; }

    [JsonPropertyName("debug")]
    public bool? Debug { get; init; }

    [JsonPropertyName("bbrProfile")]
    public string? BbrProfile { get; init; }

    [JsonPropertyName("brutalUp")]
    public JsonElement? BrutalUp { get; init; }

    [JsonPropertyName("brutalDown")]
    public JsonElement? BrutalDown { get; init; }

    [JsonPropertyName("udpHop")]
    public FinalMaskUdpHop? UdpHop { get; init; }

    [JsonPropertyName("initStreamReceiveWindow")]
    public long? InitStreamReceiveWindow { get; init; }

    [JsonPropertyName("maxStreamReceiveWindow")]
    public long? MaxStreamReceiveWindow { get; init; }

    [JsonPropertyName("initConnectionReceiveWindow")]
    public long? InitConnectionReceiveWindow { get; init; }

    [JsonPropertyName("maxConnectionReceiveWindow")]
    public long? MaxConnectionReceiveWindow { get; init; }

    [JsonPropertyName("maxIdleTimeout")]
    public long? MaxIdleTimeout { get; init; }

    [JsonPropertyName("keepAlivePeriod")]
    public long? KeepAlivePeriod { get; init; }

    [JsonPropertyName("disablePathMTUDiscovery")]
    public bool? DisablePathMTUDiscovery { get; init; }

    [JsonPropertyName("maxIncomingStreams")]
    public long? MaxIncomingStreams { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
