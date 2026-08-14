using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminDetails
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("username")]
    public required string Username { get; init; }

    [JsonPropertyName("telegram_id")]
    public long? TelegramId { get; init; }

    [JsonPropertyName("discord_webhook")]
    public string? DiscordWebhook { get; init; }

    [JsonPropertyName("sub_domain")]
    public string? SubDomain { get; init; }

    [JsonPropertyName("profile_title")]
    public string? ProfileTitle { get; init; }

    [JsonPropertyName("support_url")]
    public string? SupportUrl { get; init; }

    [JsonPropertyName("custom_variables")]
    public IReadOnlyList<CustomVariable>? CustomVariables { get; init; }

    [JsonPropertyName("notification_enable")]
    public UserNotificationEnable? NotificationEnable { get; init; }

    [JsonPropertyName("total_users")]
    public long TotalUsers { get; init; } = 0L;

    [JsonPropertyName("used_traffic")]
    public long UsedTraffic { get; init; } = 0L;

    [JsonPropertyName("data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName("status")]
    public AdminStatus Status { get; init; } = AdminStatus.Active;

    [JsonPropertyName("sub_template")]
    public string? SubTemplate { get; init; }

    [JsonPropertyName("lifetime_used_traffic")]
    public long? LifetimeUsedTraffic { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("role")]
    public AdminRoleData? Role { get; init; }

    [JsonPropertyName("permission_overrides")]
    public RoleLimits? PermissionOverrides { get; init; }

    [JsonPropertyName("is_disabled")]
    public required bool IsDisabled { get; init; }

    [JsonPropertyName("is_limited")]
    public required bool IsLimited { get; init; }
}
