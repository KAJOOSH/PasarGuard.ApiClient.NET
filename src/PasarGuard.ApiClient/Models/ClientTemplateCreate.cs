using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ClientTemplateCreate
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"template_type")]
    public required ClientTemplateType TemplateType { get; init; }

    [JsonPropertyName(@"content")]
    public required string Content { get; init; }

    [JsonPropertyName(@"is_default")]
    public bool IsDefault { get; init; } = false;
}
