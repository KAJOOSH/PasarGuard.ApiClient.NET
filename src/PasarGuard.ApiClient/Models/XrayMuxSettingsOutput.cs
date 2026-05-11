using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record XrayMuxSettingsOutput
{
    [JsonPropertyName(@"enabled")]
    public bool Enabled { get; init; } = false;

    [JsonPropertyName(@"concurrency")]
    public long? Concurrency { get; init; }

    [JsonPropertyName(@"xudpConcurrency")]
    public long? XudpConcurrency { get; init; }

    [JsonPropertyName(@"xudpProxyUDP443")]
    public XUDP XudpProxyUDP443 { get; init; } = XUDP.Reject;
}
