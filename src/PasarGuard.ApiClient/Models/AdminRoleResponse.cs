using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminRoleResponse
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("permissions")]
    public RolePermissions? Permissions { get; init; }

    [JsonPropertyName("limits")]
    public RoleLimits? Limits { get; init; }

    [JsonPropertyName("features")]
    public RoleFeatures? Features { get; init; }

    [JsonPropertyName("access")]
    public RoleAccess? Access { get; init; }

    [JsonPropertyName("hwid")]
    public RoleHWIDSettings? Hwid { get; init; }

    [JsonPropertyName("disabled_when_limited")]
    public bool DisabledWhenLimited { get; init; } = false;

    [JsonPropertyName("disconnect_users_when_limited")]
    public bool DisconnectUsersWhenLimited { get; init; } = true;

    [JsonPropertyName("disconnect_users_when_disabled")]
    public bool DisconnectUsersWhenDisabled { get; init; } = true;

    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("is_owner")]
    public required bool IsOwner { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }
}
