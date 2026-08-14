using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ClientTemplateModify
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; init; }
}
