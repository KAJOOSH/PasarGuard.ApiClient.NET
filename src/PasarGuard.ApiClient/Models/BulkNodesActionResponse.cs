using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkNodesActionResponse
{
    [JsonPropertyName(@"nodes")]
    public required List<string> Nodes { get; init; }

    [JsonPropertyName(@"count")]
    public required long Count { get; init; }
}
