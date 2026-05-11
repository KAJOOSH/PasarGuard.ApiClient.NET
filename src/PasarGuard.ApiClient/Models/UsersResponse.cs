using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UsersResponse
{
    [JsonPropertyName(@"users")]
    public required List<UserResponse> Users { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }
}
