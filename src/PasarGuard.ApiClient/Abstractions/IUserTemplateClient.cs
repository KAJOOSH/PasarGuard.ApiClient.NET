using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IUserTemplateClient
{
    Task<ApiResult<UserTemplateResponse>> CreateUserTemplateAsync(UserTemplateCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserTemplateResponse>> GetUserTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    Task<ApiResult<UserTemplateResponse>> ModifyUserTemplateAsync(long templateId, UserTemplateModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveUserTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    Task<ApiResult<List<UserTemplateResponse>>> GetUserTemplatesAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserTemplatesSimpleResponse>> GetUserTemplatesSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveUserTemplatesResponse>> BulkDeleteUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUserTemplatesActionResponse>> BulkDisableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUserTemplatesActionResponse>> BulkEnableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);
}
