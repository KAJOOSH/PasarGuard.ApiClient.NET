using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NotificationSettings
{
    [JsonPropertyName("notify_telegram")]
    public bool NotifyTelegram { get; init; } = false;

    [JsonPropertyName("notify_discord")]
    public bool NotifyDiscord { get; init; } = false;

    [JsonPropertyName("telegram_api_token")]
    public string? TelegramApiToken { get; init; }

    [JsonPropertyName("telegram_chat_id")]
    public long? TelegramChatId { get; init; }

    [JsonPropertyName("telegram_topic_id")]
    public long? TelegramTopicId { get; init; }

    [JsonPropertyName("discord_webhook_url")]
    public string? DiscordWebhookUrl { get; init; }

    [JsonPropertyName("channels")]
    public NotificationChannels? Channels { get; init; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; init; }

    [JsonPropertyName("max_retries")]
    public required long MaxRetries { get; init; }
}
