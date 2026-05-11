using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WireGuardSettings
{
    [JsonPropertyName(@"private_key")]
    public string? PrivateKey { get; init; }

    [JsonPropertyName(@"public_key")]
    public string? PublicKey { get; init; }

    [JsonPropertyName(@"peer_ips")]
    public List<string>? PeerIps { get; init; }
}
