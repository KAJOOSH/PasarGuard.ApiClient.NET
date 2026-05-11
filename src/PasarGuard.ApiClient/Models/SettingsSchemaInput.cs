using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record SettingsSchemaInput
{
    [JsonPropertyName(@"telegram")]
    public Telegram? Telegram { get; init; }

    [JsonPropertyName(@"discord")]
    public Discord? Discord { get; init; }

    [JsonPropertyName(@"webhook")]
    public Webhook? Webhook { get; init; }

    [JsonPropertyName(@"notification_settings")]
    public NotificationSettingsInput? NotificationSettings { get; init; }

    [JsonPropertyName(@"notification_enable")]
    public NotificationEnable? NotificationEnable { get; init; }

    [JsonPropertyName(@"subscription")]
    public SubscriptionInput? Subscription { get; init; }

    [JsonPropertyName(@"general")]
    public General? General { get; init; }
}
