using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskNoiseItem
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("packet")]
    public JsonElement? Packet { get; init; }

    [JsonPropertyName("delay")]
    public JsonElement? Delay { get; init; }

    [JsonPropertyName("rand")]
    public JsonElement? Rand { get; init; }

    [JsonPropertyName("randRange")]
    public string? RandRange { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
