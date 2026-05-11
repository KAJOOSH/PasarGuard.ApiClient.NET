using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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

    public Task<ApiResult<UserTemplateResponse>> CreateUserTemplateAsync(UserTemplateCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_template";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserTemplateResponse>> GetUserTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserTemplateResponse>> ModifyUserTemplateAsync(long templateId, UserTemplateModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<UserTemplateResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveUserTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<UserTemplateResponse>>> GetUserTemplatesAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_templates";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<List<UserTemplateResponse>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserTemplatesSimpleResponse>> GetUserTemplatesSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_templates/simple";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"search", search)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<UserTemplatesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveUserTemplatesResponse>> BulkDeleteUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_templates/bulk/delete";
        var url = path;
        return SendAsync<RemoveUserTemplatesResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUserTemplatesActionResponse>> BulkDisableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_templates/bulk/disable";
        var url = path;
        return SendAsync<BulkUserTemplatesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUserTemplatesActionResponse>> BulkEnableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user_templates/bulk/enable";
        var url = path;
        return SendAsync<BulkUserTemplatesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
