using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NotificationChannel
{
    [JsonPropertyName("telegram_chat_id")]
    public long? TelegramChatId { get; init; }

    [JsonPropertyName("telegram_topic_id")]
    public long? TelegramTopicId { get; init; }

    [JsonPropertyName("discord_webhook_url")]
    public string? DiscordWebhookUrl { get; init; }
}
