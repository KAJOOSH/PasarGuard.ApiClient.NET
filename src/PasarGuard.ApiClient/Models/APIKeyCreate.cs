using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record APIKeyCreate
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

    [JsonPropertyName("admin_id")]
    public long? AdminId { get; init; }
}
