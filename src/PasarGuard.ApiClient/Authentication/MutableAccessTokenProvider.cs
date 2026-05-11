namespace PasarGuard.ApiClient.Authentication;

public sealed class MutableAccessTokenProvider : IAccessTokenProvider
{
    private string? token;

    public void SetToken(string? value)
    {
        token = value;
    }

    public ValueTask<string?> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(token);
    }
}