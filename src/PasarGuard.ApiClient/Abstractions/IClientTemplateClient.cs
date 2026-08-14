using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IClientTemplateClient
{
    [ApiEndpoint("POST", "/api/client_template", "create_client_template")]
    Task<ApiResult<ClientTemplateResponse>> CreateClientTemplateAsync(ClientTemplateCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/client_template/{template_id}", "remove_client_template")]
    Task<ApiResult> RemoveClientTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/client_template/{template_id}", "get_client_template")]
    Task<ApiResult<ClientTemplateResponse>> GetClientTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/client_template/{template_id}", "modify_client_template")]
    Task<ApiResult<ClientTemplateResponse>> ModifyClientTemplateAsync(long templateId, ClientTemplateModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/client_templates", "get_client_templates")]
    Task<ApiResult<ClientTemplateResponseList>> GetClientTemplatesAsync(IReadOnlyList<long>? ids = null, ClientTemplateType? templateType = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/client_templates/bulk/delete", "bulk_delete_client_templates")]
    Task<ApiResult<RemoveClientTemplatesResponse>> BulkDeleteClientTemplatesAsync(BulkClientTemplateSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/client_templates/simple", "get_client_templates_simple")]
    Task<ApiResult<ClientTemplatesSimpleResponse>> GetClientTemplatesSimpleAsync(IReadOnlyList<long>? ids = null, ClientTemplateType? templateType = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
