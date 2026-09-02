using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskUdpHeaderCustomSettings
{
    [JsonPropertyName("client")]
    public IReadOnlyList<FinalMaskNoiseItem>? Client { get; init; }

    [JsonPropertyName("server")]
    public IReadOnlyList<FinalMaskNoiseItem>? Server { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
