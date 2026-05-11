using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record DownloadLink
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"url")]
    public required string Url { get; init; }

    [JsonPropertyName(@"language")]
    public required Language Language { get; init; }
}
