using Microsoft.Extensions.Options;
using PasarGuard.ApiClient.Configuration;

namespace PasarGuard.ApiClient.Authentication;

public sealed class MutableAccessTokenProvider : IAccessTokenProvider
{
    private string? token;

    public MutableAccessTokenProvider()
    {
    }

    public MutableAccessTokenProvider(IOptions<PasarGuardClientOptions> options)
    {
        token = options.Value.BearerToken;
    }

    public void SetToken(string? value)
    {
        Volatile.Write(ref token, value);
    }

    public ValueTask<string?> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(Volatile.Read(ref token));
    }
}
