using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record AdminDetails
{
    [JsonPropertyName(@"username")]
    public required string Username { get; init; }

    [JsonPropertyName(@"telegram_id")]
    public long? TelegramId { get; init; }

    [JsonPropertyName(@"discord_webhook")]
    public string? DiscordWebhook { get; init; }

    [JsonPropertyName(@"sub_domain")]
    public string? SubDomain { get; init; }

    [JsonPropertyName(@"profile_title")]
    public string? ProfileTitle { get; init; }

    [JsonPropertyName(@"support_url")]
    public string? SupportUrl { get; init; }

    [JsonPropertyName(@"notification_enable")]
    public UserNotificationEnable? NotificationEnable { get; init; }

    [JsonPropertyName(@"id")]
    public long? Id { get; init; }

    [JsonPropertyName(@"is_sudo")]
    public required bool IsSudo { get; init; }

    [JsonPropertyName(@"total_users")]
    public long TotalUsers { get; init; } = 0L;

    [JsonPropertyName(@"used_traffic")]
    public long UsedTraffic { get; init; } = 0L;

    [JsonPropertyName(@"is_disabled")]
    public bool IsDisabled { get; init; } = false;

    [JsonPropertyName(@"discord_id")]
    public long? DiscordId { get; init; }

    [JsonPropertyName(@"sub_template")]
    public string? SubTemplate { get; init; }

    [JsonPropertyName(@"lifetime_used_traffic")]
    public long? LifetimeUsedTraffic { get; init; }

    [JsonPropertyName(@"note")]
    public string? Note { get; init; }
}
