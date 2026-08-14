using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeOutboundsLatencyResponse
{
    [JsonPropertyName("latencies")]
    public required IReadOnlyList<NodeOutboundLatency> Latencies { get; init; }
}
