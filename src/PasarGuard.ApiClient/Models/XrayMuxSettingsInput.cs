using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record XraymuxsettingsInput
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; } = false;

    [JsonPropertyName("concurrency")]
    public long? Concurrency { get; init; }

    [JsonPropertyName("xudp_concurrency")]
    public long? XudpConcurrency { get; init; }

    [JsonPropertyName("xudp_proxy_udp_443")]
    public XUDP XudpProxyUdp443 { get; init; } = XUDP.Reject;
}
