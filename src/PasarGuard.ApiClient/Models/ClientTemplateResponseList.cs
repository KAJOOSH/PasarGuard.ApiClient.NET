using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ClientTemplateResponseList
{
    [JsonPropertyName("count")]
    public required long Count { get; init; }

    [JsonPropertyName("templates")]
    public IReadOnlyList<ClientTemplateResponse> Templates { get; init; } = [];
}
