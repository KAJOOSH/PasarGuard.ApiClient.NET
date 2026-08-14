using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskXmcProfile
{
    [JsonPropertyName("username")]
    public required string Username { get; init; }

    [JsonPropertyName("uuid")]
    public required string Uuid { get; init; }

    [JsonPropertyName("texturesValue")]
    public required string TexturesValue { get; init; }

    [JsonPropertyName("texturesSignature")]
    public required string TexturesSignature { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
