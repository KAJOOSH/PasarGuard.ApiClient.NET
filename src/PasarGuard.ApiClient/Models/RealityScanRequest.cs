using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RealityScanRequest
{
    [JsonPropertyName("target")]
    public required string Target { get; init; }

    [JsonPropertyName("timeout")]
    public double? Timeout { get; init; }
}
