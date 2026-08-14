using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISetupClient
{
    [ApiEndpoint("DELETE", "/api/setup/owner", "delete_owner")]
    Task<ApiResult> DeleteOwnerAsync(string key, CancellationToken cancellationToken = default);

    [ApiEndpoint("PATCH", "/api/setup/owner", "reset_owner_password")]
    Task<ApiResult<AdminDetails>> ResetOwnerPasswordAsync(OwnerResetRequest request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/setup/owner", "create_owner")]
    Task<ApiResult<AdminDetails>> CreateOwnerAsync(OwnerCreateRequest request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/setup/owner/upgrade", "upgrade_owner")]
    Task<ApiResult<AdminDetails>> UpgradeOwnerAsync(OwnerUpgradeRequest request, CancellationToken cancellationToken = default);
}
