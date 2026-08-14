using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record TrojanSettings
{
    [JsonPropertyName("password")]
    public string? Password { get; init; }
}
