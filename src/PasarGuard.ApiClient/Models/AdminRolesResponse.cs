using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminRolesResponse
{
    [JsonPropertyName("roles")]
    public required IReadOnlyList<AdminRoleResponse> Roles { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
