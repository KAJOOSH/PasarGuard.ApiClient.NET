using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ShadowsocksSettings
{
    [JsonPropertyName(@"password")]
    public string? Password { get; init; }

    [JsonPropertyName(@"method")]
    public ShadowsocksMethods Method { get; init; } = ShadowsocksMethods.Chacha20IetfPoly1305;
}
