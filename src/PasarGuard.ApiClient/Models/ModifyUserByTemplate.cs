using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ModifyUserByTemplate
{
    [JsonPropertyName(@"user_template_id")]
    public required long UserTemplateId { get; init; }

    [JsonPropertyName(@"note")]
    public string? Note { get; init; }
}
