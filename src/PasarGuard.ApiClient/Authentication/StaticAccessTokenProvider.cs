
using Microsoft.Extensions.Options;
using PasarGuard.ApiClient.Configuration;

namespace PasarGuard.ApiClient.Authentication;

public sealed class StaticAccessTokenProvider : IAccessTokenProvider
{
    private readonly IOptionsMonitor<PasarGuardClientOptions> options;

    public StaticAccessTokenProvider(IOptionsMonitor<PasarGuardClientOptions> options)
    {
        this.options = options;
    }

    public ValueTask<string?> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(options.CurrentValue.BearerToken);
    }
}
