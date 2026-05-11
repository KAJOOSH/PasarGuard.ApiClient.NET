using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IClientTemplateClient
{
    Task<ApiResult<ClientTemplateResponse>> CreateClientTemplateAsync(ClientTemplateCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<ClientTemplateResponse>> GetClientTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    Task<ApiResult<ClientTemplateResponse>> ModifyClientTemplateAsync(long templateId, ClientTemplateModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveClientTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    Task<ApiResult<ClientTemplateResponseList>> GetClientTemplatesAsync(ClientTemplateType? templateType = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    Task<ApiResult<ClientTemplatesSimpleResponse>> GetClientTemplatesSimpleAsync(ClientTemplateType? templateType = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveClientTemplatesResponse>> BulkDeleteClientTemplatesAsync(BulkClientTemplateSelection request, CancellationToken cancellationToken = default);
}
