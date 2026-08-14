using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminRolesSimpleResponse
{
    [JsonPropertyName("roles")]
    public required IReadOnlyList<AdminRoleSimple> Roles { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
