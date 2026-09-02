using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BaseHost
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("remark")]
    public required string Remark { get; init; }

    [JsonPropertyName("address")]
    public IReadOnlyList<string>? Address { get; init; }

    [JsonPropertyName("inbound_tag")]
    public string? InboundTag { get; init; }

    [JsonPropertyName("port")]
    public long? Port { get; init; }

    [JsonPropertyName("sni")]
    public IReadOnlyList<string>? Sni { get; init; }

    [JsonPropertyName("host")]
    public IReadOnlyList<string>? Host { get; init; }

    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("security")]
    public ProxyHostSecurity Security { get; init; } = ProxyHostSecurity.InboundDefault;

    [JsonPropertyName("alpn")]
    public IReadOnlyList<ProxyHostALPN>? Alpn { get; init; }

    [JsonPropertyName("fingerprint")]
    public ProxyHostFingerprint Fingerprint { get; init; } = ProxyHostFingerprint.Empty;

    [JsonPropertyName("allowinsecure")]
    public bool? Allowinsecure { get; init; }

    [JsonPropertyName("is_disabled")]
    public bool IsDisabled { get; init; } = false;

    [JsonPropertyName("http_headers")]
    public IReadOnlyDictionary<string, string>? HttpHeaders { get; init; }

    [JsonPropertyName("transport_settings")]
    public TransportSettings? TransportSettings { get; init; }

    [JsonPropertyName("mux_settings")]
    public MuxsettingsOutput? MuxSettings { get; init; }

    [JsonPropertyName("fragment_settings")]
    public FragmentSettings? FragmentSettings { get; init; }

    [JsonPropertyName("noise_settings")]
    public NoiseSettings? NoiseSettings { get; init; }

    [JsonPropertyName("random_user_agent")]
    public bool RandomUserAgent { get; init; } = false;

    [JsonPropertyName("use_sni_as_host")]
    public bool UseSniAsHost { get; init; } = false;

    [JsonPropertyName("vless_route")]
    public string? VlessRoute { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }

    [JsonPropertyName("status")]
    public IReadOnlyList<UserStatus>? Status { get; init; }

    [JsonPropertyName("ech_config_list")]
    public string? EchConfigList { get; init; }

    [JsonPropertyName("ech_query_strategy")]
    public ECHQueryStrategy? EchQueryStrategy { get; init; }

    [JsonPropertyName("pinned_peer_cert_sha256")]
    public string? PinnedPeerCertSha256 { get; init; }

    [JsonPropertyName("verify_peer_cert_by_name")]
    public IReadOnlyList<string>? VerifyPeerCertByName { get; init; }

    [JsonPropertyName("wireguard_overrides")]
    public WireGuardHostOverrides? WireguardOverrides { get; init; }

    [JsonPropertyName("subscription_templates")]
    public SubscriptionTemplates? SubscriptionTemplates { get; init; }

    [JsonPropertyName("final_mask_settings")]
    public FinalMask? FinalMaskSettings { get; init; }

    [JsonPropertyName("cipher_suites")]
    public string? CipherSuites { get; init; }
}
