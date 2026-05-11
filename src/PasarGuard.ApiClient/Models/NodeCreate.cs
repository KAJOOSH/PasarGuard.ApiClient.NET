using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NodeCreate
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"address")]
    public required string Address { get; init; }

    [JsonPropertyName(@"port")]
    public long Port { get; init; } = 62050L;

    [JsonPropertyName(@"api_port")]
    public long ApiPort { get; init; } = 62051L;

    [JsonPropertyName(@"usage_coefficient")]
    public double UsageCoefficient { get; init; } = 1.0;

    [JsonPropertyName(@"connection_type")]
    public required NodeConnectionType ConnectionType { get; init; }

    [JsonPropertyName(@"server_ca")]
    public required string ServerCa { get; init; }

    [JsonPropertyName(@"keep_alive")]
    public required long KeepAlive { get; init; }

    [JsonPropertyName(@"core_config_id")]
    public required long CoreConfigId { get; init; }

    [JsonPropertyName(@"api_key")]
    public required string ApiKey { get; init; }

    [JsonPropertyName(@"data_limit")]
    public long DataLimit { get; init; } = 0L;

    [JsonPropertyName(@"data_limit_reset_strategy")]
    public DataLimitResetStrategy DataLimitResetStrategy { get; init; } = DataLimitResetStrategy.NoReset;

    [JsonPropertyName(@"reset_time")]
    public long ResetTime { get; init; } = -1L;

    [JsonPropertyName(@"default_timeout")]
    public long DefaultTimeout { get; init; } = 10L;

    [JsonPropertyName(@"internal_timeout")]
    public long InternalTimeout { get; init; } = 15L;

    [JsonPropertyName(@"proxy_url")]
    public string? ProxyUrl { get; init; }
}
