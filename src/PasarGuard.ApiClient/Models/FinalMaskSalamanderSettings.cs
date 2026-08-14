using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskSalamanderSettings
{
    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("packetSize")]
    public JsonElement? PacketSize { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
