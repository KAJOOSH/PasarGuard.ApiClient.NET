using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RealityScanResult
{
    [JsonPropertyName("target")]
    public required string Target { get; init; }

    [JsonPropertyName("host")]
    public required string Host { get; init; }

    [JsonPropertyName("ip")]
    public string? Ip { get; init; }

    [JsonPropertyName("port")]
    public required long Port { get; init; }

    [JsonPropertyName("sni")]
    public string? Sni { get; init; }

    [JsonPropertyName("sni_discovered")]
    public bool SniDiscovered { get; init; } = false;

    [JsonPropertyName("feasible")]
    public required bool Feasible { get; init; }

    [JsonPropertyName("tls13")]
    public required bool Tls13 { get; init; }

    [JsonPropertyName("tls_version")]
    public string? TlsVersion { get; init; }

    [JsonPropertyName("h2")]
    public required bool H2 { get; init; }

    [JsonPropertyName("alpn")]
    public string? Alpn { get; init; }

    [JsonPropertyName("x25519")]
    public bool? X25519 { get; init; }

    [JsonPropertyName("post_quantum")]
    public bool? PostQuantum { get; init; }

    [JsonPropertyName("curve")]
    public string? Curve { get; init; }

    [JsonPropertyName("h3")]
    public bool H3 { get; init; } = false;

    [JsonPropertyName("cert_valid")]
    public required bool CertValid { get; init; }

    [JsonPropertyName("cert_subject")]
    public string? CertSubject { get; init; }

    [JsonPropertyName("cert_issuer")]
    public string? CertIssuer { get; init; }

    [JsonPropertyName("not_after")]
    public string? NotAfter { get; init; }

    [JsonPropertyName("server_names")]
    public IReadOnlyList<string>? ServerNames { get; init; }

    [JsonPropertyName("latency_ms")]
    public long? LatencyMs { get; init; }

    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
