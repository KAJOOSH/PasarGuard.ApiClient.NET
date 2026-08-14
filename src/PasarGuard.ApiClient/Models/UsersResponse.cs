using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UsersResponse
{
    [JsonPropertyName("users")]
    public required IReadOnlyList<UserResponse> Users { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
