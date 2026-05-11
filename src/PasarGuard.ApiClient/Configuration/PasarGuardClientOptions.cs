
namespace PasarGuard.ApiClient.Configuration;

public sealed class PasarGuardClientOptions
{
    public const string SectionName = "PasarGuardClient";
    public const string HttpClientName = "PasarGuardApi";

    public string BaseUrl { get; init; } = string.Empty;
    public int TimeoutSeconds { get; init; } = 100;
    public string? BearerToken { get; init; }
    public string AuthorizationScheme { get; init; } = "Bearer";

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:BaseUrl' is required.");
        }

        if (TimeoutSeconds <= 0)
        {
            throw new InvalidOperationException($"Configuration value '{SectionName}:TimeoutSeconds' must be greater than zero.");
        }
    }
}
