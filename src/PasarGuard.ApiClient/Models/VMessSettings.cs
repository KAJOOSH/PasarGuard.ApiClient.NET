using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record VMessSettings
{
    [JsonPropertyName(@"id")]
    public Guid? Id { get; init; }
}
