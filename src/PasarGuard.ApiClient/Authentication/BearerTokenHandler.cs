
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using PasarGuard.ApiClient.Configuration;

namespace PasarGuard.ApiClient.Authentication;

public sealed class BearerTokenHandler : DelegatingHandler
{
    private readonly IAccessTokenProvider tokenProvider;
    private readonly IOptionsMonitor<PasarGuardClientOptions> options;

    public BearerTokenHandler(IAccessTokenProvider tokenProvider, IOptionsMonitor<PasarGuardClientOptions> options)
    {
        this.tokenProvider = tokenProvider;
        this.options = options;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await tokenProvider.GetTokenAsync(cancellationToken).ConfigureAwait(false);

        if (!string.IsNullOrWhiteSpace(token) && request.Headers.Authorization is null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(options.CurrentValue.AuthorizationScheme, token);
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
