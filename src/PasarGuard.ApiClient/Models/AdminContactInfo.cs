using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminContactInfo
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
}
