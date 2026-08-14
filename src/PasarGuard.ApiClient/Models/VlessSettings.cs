using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record VlessSettings
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
