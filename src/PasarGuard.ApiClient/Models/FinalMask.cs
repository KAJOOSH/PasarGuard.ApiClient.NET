using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMask
{
    [JsonPropertyName("tcp")]
    public IReadOnlyList<FinalMaskTcpLayer>? Tcp { get; init; }

    [JsonPropertyName("udp")]
    public IReadOnlyList<FinalMaskUdpLayer>? Udp { get; init; }

    [JsonPropertyName("quicParams")]
    public FinalMaskQuicParams? QuicParams { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
