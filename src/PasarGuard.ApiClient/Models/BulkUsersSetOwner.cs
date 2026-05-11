using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record BulkUsersSetOwner
{
    [JsonPropertyName(@"ids")]
    public List<long>? Ids { get; init; }

    [JsonPropertyName(@"admin_username")]
    public required string AdminUsername { get; init; }
}
