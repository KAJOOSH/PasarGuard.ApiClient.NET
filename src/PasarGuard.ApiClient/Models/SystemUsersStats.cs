using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SystemUsersStats
{
    [JsonPropertyName("total_user")]
    public required long TotalUser { get; init; }

    [JsonPropertyName("online_users")]
    public required long OnlineUsers { get; init; }

    [JsonPropertyName("active_users")]
    public required long ActiveUsers { get; init; }

    [JsonPropertyName("on_hold_users")]
    public required long OnHoldUsers { get; init; }

    [JsonPropertyName("disabled_users")]
    public required long DisabledUsers { get; init; }

    [JsonPropertyName("expired_users")]
    public required long ExpiredUsers { get; init; }

    [JsonPropertyName("limited_users")]
    public required long LimitedUsers { get; init; }

    [JsonPropertyName("incoming_bandwidth")]
    public required long IncomingBandwidth { get; init; }

    [JsonPropertyName("outgoing_bandwidth")]
    public required long OutgoingBandwidth { get; init; }
}
