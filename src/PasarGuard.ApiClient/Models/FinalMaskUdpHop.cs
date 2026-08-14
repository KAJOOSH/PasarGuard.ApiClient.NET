using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskUdpHop
{
    [JsonPropertyName("ports")]
    public string? Ports { get; init; }

    [JsonPropertyName("interval")]
    public JsonElement? Interval { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
