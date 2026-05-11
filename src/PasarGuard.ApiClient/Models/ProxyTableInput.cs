using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ProxyTableInput
{
    [JsonPropertyName(@"vmess")]
    public VMessSettings? Vmess { get; init; }

    [JsonPropertyName(@"vless")]
    public VlessSettings? Vless { get; init; }

    [JsonPropertyName(@"trojan")]
    public TrojanSettings? Trojan { get; init; }

    [JsonPropertyName(@"shadowsocks")]
    public ShadowsocksSettings? Shadowsocks { get; init; }

    [JsonPropertyName(@"wireguard")]
    public WireGuardSettings? Wireguard { get; init; }

    [JsonPropertyName(@"hysteria")]
    public HysteriaSettings? Hysteria { get; init; }
}
