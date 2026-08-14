using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskXdnsSettings
{
    [JsonPropertyName("domains")]
    public IReadOnlyList<string>? Domains { get; init; }

    [JsonPropertyName("resolvers")]
    public IReadOnlyList<string>? Resolvers { get; init; }

    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
