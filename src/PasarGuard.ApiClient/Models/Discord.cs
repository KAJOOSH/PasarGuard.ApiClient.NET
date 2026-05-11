using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record Discord
{
    [JsonPropertyName(@"enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName(@"token")]
    public string? Token { get; init; }

    [JsonPropertyName(@"proxy_url")]
    public string? ProxyUrl { get; init; }
}
