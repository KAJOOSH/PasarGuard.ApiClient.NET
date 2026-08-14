using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISettingsClient
{
    [ApiEndpoint("GET", "/api/settings", "get_settings")]
    Task<ApiResult<SettingsSchema>> GetSettingsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/settings", "modify_settings")]
    Task<ApiResult<SettingsSchema>> ModifySettingsAsync(SettingsSchema request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/settings/general", "get_general_settings")]
    Task<ApiResult<General>> GetGeneralSettingsAsync(CancellationToken cancellationToken = default);
}
