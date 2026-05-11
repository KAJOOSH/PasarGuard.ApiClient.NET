using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserSubscriptionUpdateSchema
{
    [JsonPropertyName(@"created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName(@"user_agent")]
    public required string UserAgent { get; init; }
}
