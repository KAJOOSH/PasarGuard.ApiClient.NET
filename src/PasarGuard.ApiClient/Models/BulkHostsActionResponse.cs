using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkHostsActionResponse
{
    [JsonPropertyName(@"hosts")]
    public required List<string> Hosts { get; init; }

    [JsonPropertyName(@"count")]
    public required long Count { get; init; }
}
