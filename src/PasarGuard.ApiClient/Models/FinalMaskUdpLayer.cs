using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskUdpLayer
{
    [JsonPropertyName("type")]
    public required FinalMaskUdpType Type { get; init; }

    [JsonPropertyName("settings")]
    public JsonElement? Settings { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
