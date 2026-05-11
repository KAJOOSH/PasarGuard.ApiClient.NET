using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NotificationEnable
{
    [JsonPropertyName(@"admin")]
    public AdminNotificationEnable? Admin { get; init; }

    [JsonPropertyName(@"core")]
    public BaseNotificationEnable? Core { get; init; }

    [JsonPropertyName(@"group")]
    public BaseNotificationEnable? Group { get; init; }

    [JsonPropertyName(@"host")]
    public HostNotificationEnable? Host { get; init; }

    [JsonPropertyName(@"node")]
    public NodeNotificationEnable? Node { get; init; }

    [JsonPropertyName(@"user")]
    public UserNotificationEnable? User { get; init; }

    [JsonPropertyName(@"user_template")]
    public BaseNotificationEnable? UserTemplate { get; init; }

    [JsonPropertyName(@"days_left")]
    public bool DaysLeft { get; init; } = true;

    [JsonPropertyName(@"percentage_reached")]
    public bool PercentageReached { get; init; } = true;
}
