using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record RemoveAdminsResponse
{
    [JsonPropertyName(@"admins")]
    public required List<string> Admins { get; init; }

    [JsonPropertyName(@"count")]
    public required long Count { get; init; }
}
