using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskTcpLayer
{
    [JsonPropertyName("type")]
    public required FinalMaskTcpType Type { get; init; }

    [JsonPropertyName("settings")]
    public JsonElement? Settings { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
