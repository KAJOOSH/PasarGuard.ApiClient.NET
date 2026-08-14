using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class AdminRolesClient : ApiClientBase, IAdminRolesClient
{
    public AdminRolesClient(HttpClient httpClient, ILogger<AdminRolesClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/admin-role", "create_role")]
    public Task<ApiResult<AdminRoleResponse>> CreateRoleAsync(AdminRoleCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admin-role";
        var url = path;
        return SendAsync<AdminRoleResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin-role/{role_id}", "delete_role")]
    public Task<ApiResult> DeleteRoleAsync(long roleId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin-role/{UrlEncoding.EncodePathSegment(roleId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin-role/{role_id}", "get_role")]
    public Task<ApiResult<AdminRoleResponse>> GetRoleAsync(long roleId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin-role/{UrlEncoding.EncodePathSegment(roleId)}";
        var url = path;
        return SendAsync<AdminRoleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/admin-role/{role_id}", "modify_role")]
    public Task<ApiResult<AdminRoleResponse>> ModifyRoleAsync(long roleId, AdminRoleModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin-role/{UrlEncoding.EncodePathSegment(roleId)}";
        var url = path;
        return SendAsync<AdminRoleResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin-roles", "get_roles")]
    public Task<ApiResult<AdminRolesResponse>> GetRolesAsync(string? search = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/admin-roles";
        var query = new QueryStringBuilder()
            .Add("search", search)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("sort", sort);
        var url = query.Build(path);
        return SendAsync<AdminRolesResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin-roles/simple", "get_roles_simple")]
    public Task<ApiResult<AdminRolesSimpleResponse>> GetRolesSimpleAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/admin-roles/simple";
        var url = path;
        return SendAsync<AdminRolesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
