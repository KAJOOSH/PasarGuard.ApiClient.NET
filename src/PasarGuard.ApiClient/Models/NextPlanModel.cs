using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record NextPlanModel
{
    [JsonPropertyName(@"user_template_id")]
    public long? UserTemplateId { get; init; }

    [JsonPropertyName(@"data_limit")]
    public long? DataLimit { get; init; }

    [JsonPropertyName(@"expire")]
    public long? Expire { get; init; }

    [JsonPropertyName(@"add_remaining_traffic")]
    public bool AddRemainingTraffic { get; init; } = false;
}
