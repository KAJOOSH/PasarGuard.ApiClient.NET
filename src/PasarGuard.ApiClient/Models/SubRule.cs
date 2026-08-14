using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SubRule
{
    [JsonPropertyName("pattern")]
    public required string Pattern { get; init; }

    [JsonPropertyName("target")]
    public required ConfigFormat Target { get; init; }

    [JsonPropertyName("response_headers")]
    public IReadOnlyDictionary<string, JsonElement>? ResponseHeaders { get; init; }
}
