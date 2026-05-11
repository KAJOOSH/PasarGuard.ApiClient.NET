using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WireGuardPeerIPsReallocateResponse
{
    [JsonPropertyName(@"wireguard_inbound_tags")]
    public required long WireguardInboundTags { get; init; }

    [JsonPropertyName(@"candidates")]
    public required long Candidates { get; init; }

    [JsonPropertyName(@"updated")]
    public required long Updated { get; init; }

    [JsonPropertyName(@"dry_run")]
    public required bool DryRun { get; init; }

    [JsonPropertyName(@"sample_usernames")]
    public required List<string> SampleUsernames { get; init; }

    [JsonPropertyName(@"affected_users")]
    public required long AffectedUsers { get; init; }
}
