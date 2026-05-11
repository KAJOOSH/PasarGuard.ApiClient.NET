using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NotificationChannels
{
    [JsonPropertyName(@"admin")]
    public NotificationChannel? Admin { get; init; }

    [JsonPropertyName(@"core")]
    public NotificationChannel? Core { get; init; }

    [JsonPropertyName(@"group")]
    public NotificationChannel? Group { get; init; }

    [JsonPropertyName(@"host")]
    public NotificationChannel? Host { get; init; }

    [JsonPropertyName(@"node")]
    public NotificationChannel? Node { get; init; }

    [JsonPropertyName(@"user")]
    public NotificationChannel? User { get; init; }

    [JsonPropertyName(@"user_template")]
    public NotificationChannel? UserTemplate { get; init; }
}
