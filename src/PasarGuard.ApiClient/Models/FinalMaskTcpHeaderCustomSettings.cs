using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskTcpHeaderCustomSettings
{
    [JsonPropertyName("clients")]
    public IReadOnlyList<IReadOnlyList<XrayNoiseSettings>>? Clients { get; init; }

    [JsonPropertyName("servers")]
    public IReadOnlyList<IReadOnlyList<XrayNoiseSettings>>? Servers { get; init; }

    [JsonPropertyName("errors")]
    public IReadOnlyList<IReadOnlyList<XrayNoiseSettings>>? Errors { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
