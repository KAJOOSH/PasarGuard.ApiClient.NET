using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record InboundSummary
{
    [JsonPropertyName("tag")]
    public required string Tag { get; init; }

    [JsonPropertyName("protocol")]
    public required string Protocol { get; init; }

    [JsonPropertyName("network")]
    public string? Network { get; init; }
}
