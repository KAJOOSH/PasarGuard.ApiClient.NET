using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HysteriaSettings
{
    [JsonPropertyName("auth")]
    public string? Auth { get; init; }
}
