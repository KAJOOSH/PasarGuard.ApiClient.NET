using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WireGuardHostOverrides
{
    [JsonPropertyName(@"allowed_ips")]
    public List<string>? AllowedIps { get; init; }

    [JsonPropertyName(@"mtu")]
    public long? Mtu { get; init; }

    [JsonPropertyName(@"reserved")]
    public string? Reserved { get; init; }

    [JsonPropertyName(@"keepalive_seconds")]
    public long? KeepaliveSeconds { get; init; }

    [JsonPropertyName(@"dns")]
    public List<string>? Dns { get; init; }
}
