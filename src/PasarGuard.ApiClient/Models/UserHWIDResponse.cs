using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserHWIDResponse
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("hwid")]
    public required string Hwid { get; init; }

    [JsonPropertyName("device_os")]
    public string? DeviceOs { get; init; }

    [JsonPropertyName("os_version")]
    public string? OsVersion { get; init; }

    [JsonPropertyName("device_model")]
    public string? DeviceModel { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("last_used_at")]
    public required DateTimeOffset LastUsedAt { get; init; }
}
