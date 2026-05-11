using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserIPListAll
{
    [JsonPropertyName(@"nodes")]
    public required Dictionary<string, UserIPList?> Nodes { get; init; }
}
