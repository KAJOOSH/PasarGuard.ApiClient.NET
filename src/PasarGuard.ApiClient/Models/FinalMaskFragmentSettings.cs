using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskFragmentSettings
{
    [JsonPropertyName("packets")]
    public string? Packets { get; init; }

    [JsonPropertyName("lengths")]
    public IReadOnlyList<JsonElement>? Lengths { get; init; }

    [JsonPropertyName("delays")]
    public IReadOnlyList<JsonElement>? Delays { get; init; }

    [JsonPropertyName("maxSplit")]
    public JsonElement? MaxSplit { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
