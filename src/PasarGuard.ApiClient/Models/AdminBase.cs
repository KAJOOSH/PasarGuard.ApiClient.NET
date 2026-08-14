using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminBase
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("username")]
    public required string Username { get; init; }
}
