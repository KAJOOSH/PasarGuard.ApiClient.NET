using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ApplicationOutput
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"icon_url")]
    public string IconUrl { get; init; } = @"";

    [JsonPropertyName(@"import_url")]
    public string ImportUrl { get; init; } = @"";

    [JsonPropertyName(@"description")]
    public Dictionary<string, string>? Description { get; init; }

    [JsonPropertyName(@"recommended")]
    public bool Recommended { get; init; } = false;

    [JsonPropertyName(@"platform")]
    public required Platform Platform { get; init; }

    [JsonPropertyName(@"download_links")]
    public required List<DownloadLink> DownloadLinks { get; init; }
}
