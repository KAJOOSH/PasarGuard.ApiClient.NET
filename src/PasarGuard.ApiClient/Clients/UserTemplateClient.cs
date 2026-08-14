using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class UserTemplateClient : ApiClientBase, IUserTemplateClient
{
    public UserTemplateClient(HttpClient httpClient, ILogger<UserTemplateClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/user_template", "create_user_template")]
    public Task<ApiResult<UserTemplateResponse>> CreateUserTemplateAsync(UserTemplateCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_template";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/user_template/{template_id}", "remove_user_template")]
    public Task<ApiResult> RemoveUserTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user_template/{template_id}", "get_user_template")]
    public Task<ApiResult<UserTemplateResponse>> GetUserTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user_template/{template_id}", "modify_user_template")]
    public Task<ApiResult<UserTemplateResponse>> ModifyUserTemplateAsync(long templateId, UserTemplateModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user_templates", "get_user_templates")]
    public Task<ApiResult<IReadOnlyList<UserTemplateResponse>>> GetUserTemplatesAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_templates";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<IReadOnlyList<UserTemplateResponse>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user_templates/bulk/delete", "bulk_delete_user_templates")]
    public Task<ApiResult<RemoveUserTemplatesResponse>> BulkDeleteUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_templates/bulk/delete";
        var url = path;
        return SendAsync<RemoveUserTemplatesResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user_templates/bulk/disable", "bulk_disable_user_templates")]
    public Task<ApiResult<BulkUserTemplatesActionResponse>> BulkDisableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_templates/bulk/disable";
        var url = path;
        return SendAsync<BulkUserTemplatesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user_templates/bulk/enable", "bulk_enable_user_templates")]
    public Task<ApiResult<BulkUserTemplatesActionResponse>> BulkEnableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_templates/bulk/enable";
        var url = path;
        return SendAsync<BulkUserTemplatesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user_templates/simple", "get_user_templates_simple")]
    public Task<ApiResult<UserTemplatesSimpleResponse>> GetUserTemplatesSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/user_templates/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<UserTemplatesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
