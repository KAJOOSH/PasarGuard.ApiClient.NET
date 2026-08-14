using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Subscription
{
    [JsonPropertyName("url_prefix")]
    public string UrlPrefix { get; init; } = "";

    [JsonPropertyName("update_interval")]
    public long UpdateInterval { get; init; } = 12L;

    [JsonPropertyName("support_url")]
    public string SupportUrl { get; init; } = "https://t.me/";

    [JsonPropertyName("profile_title")]
    public string ProfileTitle { get; init; } = "Subscription";

    [JsonPropertyName("announce")]
    public string Announce { get; init; } = "";

    [JsonPropertyName("announce_url")]
    public string AnnounceUrl { get; init; } = "";

    [JsonPropertyName("response_headers")]
    public IReadOnlyDictionary<string, JsonElement>? ResponseHeaders { get; init; }

    [JsonPropertyName("rules")]
    public required IReadOnlyList<SubRule> Rules { get; init; }

    [JsonPropertyName("manual_sub_request")]
    public SubFormatEnable? ManualSubRequest { get; init; }

    [JsonPropertyName("applications")]
    public IReadOnlyList<Application>? Applications { get; init; }

    [JsonPropertyName("allow_browser_config")]
    public bool AllowBrowserConfig { get; init; } = true;

    [JsonPropertyName("disable_sub_template")]
    public bool DisableSubTemplate { get; init; } = false;

    [JsonPropertyName("randomize_order")]
    public bool RandomizeOrder { get; init; } = false;

    [JsonPropertyName("custom_variables")]
    public IReadOnlyList<CustomVariable>? CustomVariables { get; init; }
}
