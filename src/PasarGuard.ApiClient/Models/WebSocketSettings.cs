using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record WebSocketSettings
{
    [JsonPropertyName("heartbeatPeriod")]
    public long? HeartbeatPeriod { get; init; }
}
