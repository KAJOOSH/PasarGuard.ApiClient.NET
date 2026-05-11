using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ClientTemplateResponseList
{
    [JsonPropertyName(@"count")]
    public required long Count { get; init; }

    [JsonPropertyName(@"templates")]
    public List<ClientTemplateResponse> Templates { get; init; } = new();
}
