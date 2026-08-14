using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SingBoxFragmentSettings
{
    [JsonPropertyName("fragment")]
    public bool Fragment { get; init; } = false;

    [JsonPropertyName("fragment_fallback_delay")]
    public string FragmentFallbackDelay { get; init; } = "";

    [JsonPropertyName("record_fragment")]
    public bool RecordFragment { get; init; } = false;
}
