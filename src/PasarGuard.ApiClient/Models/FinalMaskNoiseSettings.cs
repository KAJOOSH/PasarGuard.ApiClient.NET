using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskNoiseSettings
{
    [JsonPropertyName("reset")]
    public JsonElement? Reset { get; init; }

    [JsonPropertyName("noise")]
    public IReadOnlyList<FinalMaskNoiseItem>? Noise { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
