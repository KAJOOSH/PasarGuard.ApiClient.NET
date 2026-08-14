using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminModify
{
    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("telegram_id")]
    public long? TelegramId { get; init; }

    [JsonPropertyName("discord_webhook")]
    public string? DiscordWebhook { get; init; }

    [JsonPropertyName("status")]
    public AdminStatus? Status { get; init; }

    [JsonPropertyName("data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName("sub_template")]
    public string? SubTemplate { get; init; }

    [JsonPropertyName("sub_domain")]
    public string? SubDomain { get; init; }

    [JsonPropertyName("profile_title")]
    public string? ProfileTitle { get; init; }

    [JsonPropertyName("support_url")]
    public string? SupportUrl { get; init; }

    [JsonPropertyName("custom_variables")]
    public IReadOnlyList<CustomVariable>? CustomVariables { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("notification_enable")]
    public UserNotificationEnable? NotificationEnable { get; init; }

    [JsonPropertyName("role_id")]
    public long? RoleId { get; init; }

    [JsonPropertyName("permission_overrides")]
    public RoleLimits? PermissionOverrides { get; init; }
}
