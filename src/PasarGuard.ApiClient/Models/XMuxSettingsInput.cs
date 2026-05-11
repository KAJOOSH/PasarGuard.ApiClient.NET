using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record XMuxSettingsInput
{
    [JsonPropertyName(@"max_concurrency")]
    public object? MaxConcurrency { get; init; }

    [JsonPropertyName(@"max_connections")]
    public object? MaxConnections { get; init; }

    [JsonPropertyName(@"c_max_reuse_times")]
    public object? CMaxReuseTimes { get; init; }

    [JsonPropertyName(@"h_max_reusable_secs")]
    public object? HMaxReusableSecs { get; init; }

    [JsonPropertyName(@"h_max_request_times")]
    public object? HMaxRequestTimes { get; init; }

    [JsonPropertyName(@"h_keep_alive_period")]
    public long? HKeepAlivePeriod { get; init; }
}
