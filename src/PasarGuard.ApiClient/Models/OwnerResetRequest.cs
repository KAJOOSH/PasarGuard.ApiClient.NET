using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record OwnerResetRequest
{
    [JsonPropertyName("key")]
    public required string Key { get; init; }

    [JsonPropertyName("password")]
    public required string Password { get; init; }
}
