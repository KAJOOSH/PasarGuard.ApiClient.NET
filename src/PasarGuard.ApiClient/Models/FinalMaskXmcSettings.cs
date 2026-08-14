using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskXmcSettings
{
    [JsonPropertyName("hostname")]
    public string? Hostname { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("profiles")]
    public IReadOnlyList<FinalMaskXmcProfile>? Profiles { get; init; }

    [JsonPropertyName("usernames")]
    public IReadOnlyList<string>? Usernames { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
