using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RemoveHostsResponse
{
    [JsonPropertyName("hosts")]
    public required IReadOnlyList<string> Hosts { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
