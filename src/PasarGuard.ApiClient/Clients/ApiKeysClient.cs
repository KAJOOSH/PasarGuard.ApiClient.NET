using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class ApiKeysClient : ApiClientBase, IApiKeysClient
{
    public ApiKeysClient(HttpClient httpClient, ILogger<ApiKeysClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/api_key", "create_api_key")]
    public Task<ApiResult<APIKeyCreateResponse>> CreateApiKeyAsync(APIKeyCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/api_key";
        var url = path;
        return SendAsync<APIKeyCreateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/api_key/{key_id}", "remove_api_key")]
    public Task<ApiResult> RemoveApiKeyAsync(long keyId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/api_key/{UrlEncoding.EncodePathSegment(keyId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/api_key/{key_id}", "get_api_key")]
    public Task<ApiResult<APIKeyResponse>> GetApiKeyAsync(long keyId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/api_key/{UrlEncoding.EncodePathSegment(keyId)}";
        var url = path;
        return SendAsync<APIKeyResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PATCH", "/api/api_key/{key_id}", "modify_api_key")]
    public Task<ApiResult<APIKeyResponse>> ModifyApiKeyAsync(long keyId, APIKeyUpdate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/api_key/{UrlEncoding.EncodePathSegment(keyId)}";
        var url = path;
        return SendAsync<APIKeyResponse>(HttpMethod.Patch, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/api_key/{key_id}/revoke", "revoke_api_key")]
    public Task<ApiResult<APIKeyCreateResponse>> RevokeApiKeyAsync(long keyId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/api_key/{UrlEncoding.EncodePathSegment(keyId)}/revoke";
        var url = path;
        return SendAsync<APIKeyCreateResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/api_keys", "list_api_keys")]
    public Task<ApiResult<APIKeysResponse>> ListApiKeysAsync(long? offset = null, long? limit = null, long? keyId = null, string? name = null, APIKeyStatus? status = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/api_keys";
        var query = new QueryStringBuilder()
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("key_id", keyId)
            .Add("name", name)
            .Add("status", status);
        var url = query.Build(path);
        return SendAsync<APIKeysResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/api_keys/bulk/delete", "bulk_delete_api_keys")]
    public Task<ApiResult<RemoveAPIKeysResponse>> BulkDeleteApiKeysAsync(BulkAPIKeySelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/api_keys/bulk/delete";
        var url = path;
        return SendAsync<RemoveAPIKeysResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
