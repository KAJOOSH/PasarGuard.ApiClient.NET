using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkUsersCreateResponse
{
    [JsonPropertyName(@"subscription_urls")]
    public List<string>? SubscriptionUrls { get; init; }

    [JsonPropertyName(@"created")]
    public long Created { get; init; } = 0L;
}
