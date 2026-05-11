using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record RemoveUsersResponse
{
    [JsonPropertyName(@"users")]
    public required List<string> Users { get; init; }

    [JsonPropertyName(@"count")]
    public required long Count { get; init; }
}
