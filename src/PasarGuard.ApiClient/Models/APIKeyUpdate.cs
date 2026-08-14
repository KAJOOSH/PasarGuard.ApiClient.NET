using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record APIKeyUpdate
{
    [JsonPropertyName("admin_id")]
    public long? AdminId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("permissions")]
    public RolePermissions? Permissions { get; init; }

    [JsonPropertyName("inherit_permissions")]
    public bool? InheritPermissions { get; init; }

    [JsonPropertyName("expire_date")]
    public DateTimeOffset? ExpireDate { get; init; }

    [JsonPropertyName("status")]
    public APIKeyStatus? Status { get; init; }
}
