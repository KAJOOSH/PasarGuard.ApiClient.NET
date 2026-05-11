using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserIPList
{
    [JsonPropertyName(@"ips")]
    public required Dictionary<string, long> Ips { get; init; }
}
