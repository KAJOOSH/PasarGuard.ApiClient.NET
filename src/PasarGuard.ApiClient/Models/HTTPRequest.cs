using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HTTPRequest
{
    [JsonPropertyName("version")]
    public string Version { get; init; } = "1.1";

    [JsonPropertyName("headers")]
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Headers { get; init; }

    [JsonPropertyName("method")]
    public string Method { get; init; } = "GET";
}
