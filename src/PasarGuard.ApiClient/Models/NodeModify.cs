using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeModify
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("address")]
    public string? Address { get; init; }

    [JsonPropertyName("port")]
    public long? Port { get; init; }

    [JsonPropertyName("api_port")]
    public long ApiPort { get; init; } = 62051L;

    [JsonPropertyName("usage_coefficient")]
    public double? UsageCoefficient { get; init; }

    [JsonPropertyName("connection_type")]
    public NodeConnectionType? ConnectionType { get; init; }

    [JsonPropertyName("server_ca")]
    public string? ServerCa { get; init; }

    [JsonPropertyName("keep_alive")]
    public long? KeepAlive { get; init; }

    [JsonPropertyName("core_config_id")]
    public long? CoreConfigId { get; init; }

    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    [JsonPropertyName("data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName("data_limit_reset_strategy")]
    public DataLimitResetStrategy? DataLimitResetStrategy { get; init; }

    [JsonPropertyName("reset_time")]
    public long? ResetTime { get; init; }

    [JsonPropertyName("default_timeout")]
    public long? DefaultTimeout { get; init; }

    [JsonPropertyName("internal_timeout")]
    public long? InternalTimeout { get; init; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; init; }

    [JsonPropertyName("status")]
    public NodeStatus? Status { get; init; }
}
