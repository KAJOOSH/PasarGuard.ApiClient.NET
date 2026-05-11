
namespace PasarGuard.ApiClient.Authentication;

public interface IAccessTokenProvider
{
    ValueTask<string?> GetTokenAsync(CancellationToken cancellationToken = default);
}
