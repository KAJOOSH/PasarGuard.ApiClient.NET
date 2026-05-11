using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record Token
{
    [JsonPropertyName(@"access_token")]
    public required string AccessToken { get; init; }

    [JsonPropertyName(@"token_type")]
    public string TokenType { get; init; } = @"bearer";
}
