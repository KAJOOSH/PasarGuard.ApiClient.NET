using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WebhookInfo
{
    [JsonPropertyName(@"url")]
    public required string Url { get; init; }

    [JsonPropertyName(@"secret")]
    public required string Secret { get; init; }
}
