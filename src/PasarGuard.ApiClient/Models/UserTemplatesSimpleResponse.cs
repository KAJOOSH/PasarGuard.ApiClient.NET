using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserTemplatesSimpleResponse
{
    [JsonPropertyName("templates")]
    public required IReadOnlyList<UserTemplateSimple> Templates { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
