using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record AdminsSimpleResponse
{
    [JsonPropertyName(@"admins")]
    public required List<AdminSimple> Admins { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }
}
