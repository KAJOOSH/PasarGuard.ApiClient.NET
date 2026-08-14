using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record VMessSettings
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
