using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskMkcpLegacySettings
{
    [JsonPropertyName("header")]
    public string? Header { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
