using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ClientTemplatesSimpleResponse
{
    [JsonPropertyName("templates")]
    public required IReadOnlyList<ClientTemplateSimple> Templates { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
