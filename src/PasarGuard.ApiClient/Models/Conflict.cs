using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record Conflict
{
    [JsonPropertyName(@"detail")]
    public string Detail { get; init; } = @"Entity already exists";
}
