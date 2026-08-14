using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class ClientTemplateClient : ApiClientBase, IClientTemplateClient
{
    public ClientTemplateClient(HttpClient httpClient, ILogger<ClientTemplateClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/client_template", "create_client_template")]
    public Task<ApiResult<ClientTemplateResponse>> CreateClientTemplateAsync(ClientTemplateCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/client_template";
        var url = path;
        return SendAsync<ClientTemplateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/client_template/{template_id}", "remove_client_template")]
    public Task<ApiResult> RemoveClientTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/client_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/client_template/{template_id}", "get_client_template")]
    public Task<ApiResult<ClientTemplateResponse>> GetClientTemplateAsync(long templateId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/client_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<ClientTemplateResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/client_template/{template_id}", "modify_client_template")]
    public Task<ApiResult<ClientTemplateResponse>> ModifyClientTemplateAsync(long templateId, ClientTemplateModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/client_template/{UrlEncoding.EncodePathSegment(templateId)}";
        var url = path;
        return SendAsync<ClientTemplateResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/client_templates", "get_client_templates")]
    public Task<ApiResult<ClientTemplateResponseList>> GetClientTemplatesAsync(IReadOnlyList<long>? ids = null, ClientTemplateType? templateType = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/client_templates";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("template_type", templateType)
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<ClientTemplateResponseList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/client_templates/bulk/delete", "bulk_delete_client_templates")]
    public Task<ApiResult<RemoveClientTemplatesResponse>> BulkDeleteClientTemplatesAsync(BulkClientTemplateSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/client_templates/bulk/delete";
        var url = path;
        return SendAsync<RemoveClientTemplatesResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/client_templates/simple", "get_client_templates_simple")]
    public Task<ApiResult<ClientTemplatesSimpleResponse>> GetClientTemplatesSimpleAsync(IReadOnlyList<long>? ids = null, ClientTemplateType? templateType = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/client_templates/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("template_type", templateType)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<ClientTemplatesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
