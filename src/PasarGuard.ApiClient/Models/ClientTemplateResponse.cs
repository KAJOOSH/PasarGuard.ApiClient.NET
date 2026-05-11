using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ClientTemplateResponse
{
    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"template_type")]
    public required ClientTemplateType TemplateType { get; init; }

    [JsonPropertyName(@"content")]
    public required string Content { get; init; }

    [JsonPropertyName(@"is_default")]
    public required bool IsDefault { get; init; }

    [JsonPropertyName(@"is_system")]
    public required bool IsSystem { get; init; }
}
