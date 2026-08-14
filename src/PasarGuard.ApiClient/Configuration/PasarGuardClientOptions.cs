namespace PasarGuard.ApiClient.Configuration;

public sealed class PasarGuardClientOptions
{
    public const string SectionName = "PasarGuardClient";
    public const string HttpClientName = "PasarGuardApi";

    public string BaseUrl { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 100;
    public string? BearerToken { get; set; }
    public string AuthorizationScheme { get; set; } = "Bearer";

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:BaseUrl' is required.");
        }

        if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out var baseUri) ||
            (!baseUri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) &&
             !baseUri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:BaseUrl' must be an absolute HTTP or HTTPS URL.");
        }

        if (TimeoutSeconds <= 0)
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:TimeoutSeconds' must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(AuthorizationScheme))
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:AuthorizationScheme' is required.");
        }
    }
}
