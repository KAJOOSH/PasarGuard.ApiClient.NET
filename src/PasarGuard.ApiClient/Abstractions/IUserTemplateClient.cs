using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IUserTemplateClient
{
    [ApiEndpoint("POST", "/api/user_template", "create_user_template")]
    Task<ApiResult<UserTemplateResponse>> CreateUserTemplateAsync(UserTemplateCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/user_template/{template_id}", "remove_user_template")]
    Task<ApiResult> RemoveUserTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user_template/{template_id}", "get_user_template")]
    Task<ApiResult<UserTemplateResponse>> GetUserTemplateAsync(long templateId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user_template/{template_id}", "modify_user_template")]
    Task<ApiResult<UserTemplateResponse>> ModifyUserTemplateAsync(long templateId, UserTemplateModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user_templates", "get_user_templates")]
    Task<ApiResult<IReadOnlyList<UserTemplateResponse>>> GetUserTemplatesAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user_templates/bulk/delete", "bulk_delete_user_templates")]
    Task<ApiResult<RemoveUserTemplatesResponse>> BulkDeleteUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user_templates/bulk/disable", "bulk_disable_user_templates")]
    Task<ApiResult<BulkUserTemplatesActionResponse>> BulkDisableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user_templates/bulk/enable", "bulk_enable_user_templates")]
    Task<ApiResult<BulkUserTemplatesActionResponse>> BulkEnableUserTemplatesAsync(BulkUserTemplateSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user_templates/simple", "get_user_templates_simple")]
    Task<ApiResult<UserTemplatesSimpleResponse>> GetUserTemplatesSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
