using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IApiKeysClient
{
    [ApiEndpoint("POST", "/api/api_key", "create_api_key")]
    Task<ApiResult<APIKeyCreateResponse>> CreateApiKeyAsync(APIKeyCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/api_key/{key_id}", "remove_api_key")]
    Task<ApiResult> RemoveApiKeyAsync(long keyId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/api_key/{key_id}", "get_api_key")]
    Task<ApiResult<APIKeyResponse>> GetApiKeyAsync(long keyId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PATCH", "/api/api_key/{key_id}", "modify_api_key")]
    Task<ApiResult<APIKeyResponse>> ModifyApiKeyAsync(long keyId, APIKeyUpdate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/api_key/{key_id}/revoke", "revoke_api_key")]
    Task<ApiResult<APIKeyCreateResponse>> RevokeApiKeyAsync(long keyId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/api_keys", "list_api_keys")]
    Task<ApiResult<APIKeysResponse>> ListApiKeysAsync(long? offset = null, long? limit = null, long? keyId = null, string? name = null, APIKeyStatus? status = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/api_keys/bulk/delete", "bulk_delete_api_keys")]
    Task<ApiResult<RemoveAPIKeysResponse>> BulkDeleteApiKeysAsync(BulkAPIKeySelection request, CancellationToken cancellationToken = default);
}
