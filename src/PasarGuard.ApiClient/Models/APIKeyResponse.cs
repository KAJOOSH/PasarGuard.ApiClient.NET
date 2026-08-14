using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record APIKeyResponse
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("permissions")]
    public RolePermissions? Permissions { get; init; }

    [JsonPropertyName("inherit_permissions")]
    public bool InheritPermissions { get; init; } = true;

    [JsonPropertyName("expire_date")]
    public DateTimeOffset? ExpireDate { get; init; }

    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("admin_id")]
    public required long AdminId { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("api_key_trimmed")]
    public required string ApiKeyTrimmed { get; init; }

    [JsonPropertyName("revoked_at")]
    public DateTimeOffset? RevokedAt { get; init; }

    [JsonPropertyName("status")]
    public APIKeyStatus Status { get; init; } = APIKeyStatus.Active;

    [JsonPropertyName("is_expired")]
    public bool IsExpired { get; init; } = false;
}
