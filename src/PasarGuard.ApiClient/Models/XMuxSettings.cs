using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record XMuxSettings
{
    [JsonPropertyName("maxConcurrency")]
    public string? MaxConcurrency { get; init; }

    [JsonPropertyName("maxConnections")]
    public string? MaxConnections { get; init; }

    [JsonPropertyName("cMaxReuseTimes")]
    public string? CMaxReuseTimes { get; init; }

    [JsonPropertyName("hMaxReusableSecs")]
    public string? HMaxReusableSecs { get; init; }

    [JsonPropertyName("hMaxRequestTimes")]
    public string? HMaxRequestTimes { get; init; }

    [JsonPropertyName("hKeepAlivePeriod")]
    public long? HKeepAlivePeriod { get; init; }
}
