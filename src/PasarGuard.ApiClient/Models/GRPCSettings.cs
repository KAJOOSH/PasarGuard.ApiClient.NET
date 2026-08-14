using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record GRPCSettings
{
    [JsonPropertyName("multi_mode")]
    public bool MultiMode { get; init; } = false;

    [JsonPropertyName("idle_timeout")]
    public long? IdleTimeout { get; init; }

    [JsonPropertyName("health_check_timeout")]
    public long? HealthCheckTimeout { get; init; }

    [JsonPropertyName("permit_without_stream")]
    public bool PermitWithoutStream { get; init; } = false;

    [JsonPropertyName("initial_windows_size")]
    public long? InitialWindowsSize { get; init; }
}
