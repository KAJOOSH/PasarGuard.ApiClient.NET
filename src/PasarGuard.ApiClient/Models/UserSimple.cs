using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UserSimple
{
    [JsonPropertyName(@"id")]
    public required long Id { get; init; }

    [JsonPropertyName(@"username")]
    public required string Username { get; init; }
}
