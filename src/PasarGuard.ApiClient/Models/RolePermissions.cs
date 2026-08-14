using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RolePermissions
{
    [JsonPropertyName("users")]
    public UsersPermissions? Users { get; init; }

    [JsonPropertyName("admins")]
    public AdminsPermissions? Admins { get; init; }

    [JsonPropertyName("nodes")]
    public NodesPermissions? Nodes { get; init; }

    [JsonPropertyName("groups")]
    public CRUDPermissions? Groups { get; init; }

    [JsonPropertyName("hosts")]
    public HostsPermissions? Hosts { get; init; }

    [JsonPropertyName("templates")]
    public CRUDPermissions? Templates { get; init; }

    [JsonPropertyName("client_templates")]
    public CRUDPermissions? ClientTemplates { get; init; }

    [JsonPropertyName("cores")]
    public CRUDPermissions? Cores { get; init; }

    [JsonPropertyName("settings")]
    public SettingsPermissions? Settings { get; init; }

    [JsonPropertyName("system")]
    public SystemPermissions? System { get; init; }

    [JsonPropertyName("hwids")]
    public HwidsPermissions? Hwids { get; init; }

    [JsonPropertyName("admin_roles")]
    public CRUDPermissions? AdminRoles { get; init; }

    [JsonPropertyName("api_keys")]
    public APIKeysPermissions? ApiKeys { get; init; }
}
