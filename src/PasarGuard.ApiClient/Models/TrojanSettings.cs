using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record TrojanSettings
{
    [JsonPropertyName(@"password")]
    public string? Password { get; init; }
}
