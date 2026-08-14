using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NoiseSettings
{
    [JsonPropertyName("xray")]
    public IReadOnlyList<XrayNoiseSettings>? Xray { get; init; }
}
