using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NoiseSettings
{
    [JsonPropertyName(@"xray")]
    public List<XrayNoiseSettings>? Xray { get; init; }
}
