using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NotificationChannels
{
    [JsonPropertyName("admin")]
    public NotificationChannel? Admin { get; init; }

    [JsonPropertyName("admin_role")]
    public NotificationChannel? AdminRole { get; init; }

    [JsonPropertyName("core")]
    public NotificationChannel? Core { get; init; }

    [JsonPropertyName("group")]
    public NotificationChannel? Group { get; init; }

    [JsonPropertyName("host")]
    public NotificationChannel? Host { get; init; }

    [JsonPropertyName("node")]
    public NotificationChannel? Node { get; init; }

    [JsonPropertyName("user")]
    public NotificationChannel? User { get; init; }

    [JsonPropertyName("user_template")]
    public NotificationChannel? UserTemplate { get; init; }

    [JsonPropertyName("api_key")]
    public NotificationChannel? ApiKey { get; init; }
}
