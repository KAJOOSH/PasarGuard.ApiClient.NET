using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RoleHWIDSettings
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; } = true;

    [JsonPropertyName("forced")]
    public bool Forced { get; init; } = false;

    [JsonPropertyName("require_hwid_for_manual_sub")]
    public bool RequireHwidForManualSub { get; init; } = false;

    [JsonPropertyName("fallback_limit")]
    public long? FallbackLimit { get; init; }

    [JsonPropertyName("min_limit")]
    public long? MinLimit { get; init; }

    [JsonPropertyName("max_limit")]
    public long? MaxLimit { get; init; }

    [JsonPropertyName("mode")]
    public HWIDMode Mode { get; init; } = HWIDMode.UseGlobal;
}
