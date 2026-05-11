using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record AdminsResponse
{
    [JsonPropertyName(@"admins")]
    public required List<AdminDetails> Admins { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }

    [JsonPropertyName(@"active")]
    public required long Active { get; init; }

    [JsonPropertyName(@"disabled")]
    public required long Disabled { get; init; }
}
