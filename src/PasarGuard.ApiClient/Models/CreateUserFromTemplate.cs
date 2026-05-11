using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record CreateUserFromTemplate
{
    [JsonPropertyName(@"user_template_id")]
    public required long UserTemplateId { get; init; }

    [JsonPropertyName(@"note")]
    public string? Note { get; init; }

    [JsonPropertyName(@"username")]
    public required string Username { get; init; }
}
