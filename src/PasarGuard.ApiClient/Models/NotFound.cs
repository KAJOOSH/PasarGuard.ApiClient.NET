using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NotFound
{
    [JsonPropertyName(@"detail")]
    public string Detail { get; init; } = @"Entity {} not found";
}
