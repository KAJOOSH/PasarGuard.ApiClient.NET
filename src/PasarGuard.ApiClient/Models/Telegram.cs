using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Telegram
{
    [JsonPropertyName("enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName("token")]
    public string? Token { get; init; }

    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; init; }

    [JsonPropertyName("webhook_secret")]
    public string? WebhookSecret { get; init; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; init; }

    [JsonPropertyName("method")]
    public RunMethod Method { get; init; } = RunMethod.Webhook;

    [JsonPropertyName("mini_app_login")]
    public bool MiniAppLogin { get; init; } = true;

    [JsonPropertyName("mini_app_web_url")]
    public string? MiniAppWebUrl { get; init; } = "";

    [JsonPropertyName("for_admins_only")]
    public bool ForAdminsOnly { get; init; } = true;
}
