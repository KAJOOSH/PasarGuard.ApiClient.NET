using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IDefaultClient
{
    [ApiEndpoint("GET", "/", "base")]
    Task<ApiResult<string>> BaseAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/health", "health")]
    Task<ApiResult<IReadOnlyDictionary<string, JsonElement>>> HealthAsync(CancellationToken cancellationToken = default);
}
