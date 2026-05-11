using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ClientTemplatesSimpleResponse
{
    [JsonPropertyName(@"templates")]
    public required List<ClientTemplateSimple> Templates { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }
}
