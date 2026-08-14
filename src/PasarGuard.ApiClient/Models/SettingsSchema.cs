using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SettingsSchema
{
    [JsonPropertyName("telegram")]
    public Telegram? Telegram { get; init; }

    [JsonPropertyName("webhook")]
    public Webhook? Webhook { get; init; }

    [JsonPropertyName("notification_settings")]
    public NotificationSettings? NotificationSettings { get; init; }

    [JsonPropertyName("notification_enable")]
    public NotificationEnable? NotificationEnable { get; init; }

    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; init; }

    [JsonPropertyName("hwid")]
    public HWIDSettings? Hwid { get; init; }

    [JsonPropertyName("general")]
    public General? General { get; init; }
}
