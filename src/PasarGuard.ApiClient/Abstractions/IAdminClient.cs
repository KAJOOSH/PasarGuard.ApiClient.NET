using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IAdminClient
{
    [ApiEndpoint("GET", "/api/admin", "get_current_admin")]
    Task<ApiResult<AdminDetails>> GetCurrentAdminAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin", "create_admin")]
    Task<ApiResult<AdminDetails>> CreateAdminAsync(AdminCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/by-id/{admin_id}", "remove_admin_by_id")]
    Task<ApiResult> RemoveAdminByIdAsync(long adminId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/admin/by-id/{admin_id}", "modify_admin_by_id")]
    Task<ApiResult<AdminDetails>> ModifyAdminByIdAsync(long adminId, AdminModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/reset", "reset_admin_usage_by_id")]
    Task<ApiResult<AdminDetails>> ResetAdminUsageByIdAsync(long adminId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin/by-id/{admin_id}/usage", "get_admin_usage_by_id")]
    Task<ApiResult<UserUsageStatsList>> GetAdminUsageByIdAsync(long adminId, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/by-id/{admin_id}/users", "remove_all_users_by_id")]
    Task<ApiResult<JsonElement>> RemoveAllUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/users/activate", "activate_all_disabled_users_by_id")]
    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/users/disable", "disable_all_active_users_by_id")]
    Task<ApiResult<JsonElement>> DisableAllActiveUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/by-username/{username}", "remove_admin_by_username")]
    Task<ApiResult> RemoveAdminByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/admin/by-username/{username}", "modify_admin_by_username")]
    Task<ApiResult<AdminDetails>> ModifyAdminByUsernameAsync(string username, AdminModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/reset", "reset_admin_usage_by_username")]
    Task<ApiResult<AdminDetails>> ResetAdminUsageByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin/by-username/{username}/usage", "get_admin_usage_by_username")]
    Task<ApiResult<UserUsageStatsList>> GetAdminUsageByUsernameAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/by-username/{username}/users", "remove_all_users_by_username")]
    Task<ApiResult<JsonElement>> RemoveAllUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/users/activate", "activate_all_disabled_users_by_username")]
    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/users/disable", "disable_all_active_users_by_username")]
    Task<ApiResult<JsonElement>> DisableAllActiveUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/miniapp/token", "admin_mini_app_token")]
    Task<ApiResult<JsonElement>> AdminMiniAppTokenAsync(string xTelegramAuthorization, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/token", "admin_token")]
    Task<ApiResult<Token>> AdminTokenAsync(BodyAdminToken request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/{username}", "remove_admin")]
    Task<ApiResult> RemoveAdminAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/admin/{username}", "modify_admin")]
    Task<ApiResult<AdminDetails>> ModifyAdminAsync(string username, AdminModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/{username}/reset", "reset_admin_usage")]
    Task<ApiResult<AdminDetails>> ResetAdminUsageAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin/{username}/usage", "get_admin_usage")]
    Task<ApiResult<UserUsageStatsList>> GetAdminUsageAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin/{username}/users", "remove_all_users")]
    Task<ApiResult<JsonElement>> RemoveAllUsersAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/{username}/users/activate", "activate_all_disabled_users")]
    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admin/{username}/users/disable", "disable_all_active_users")]
    Task<ApiResult<JsonElement>> DisableAllActiveUsersAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admins", "get_admins")]
    Task<ApiResult<AdminsResponse>> GetAdminsAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, string? username = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/delete", "bulk_delete_admins")]
    Task<ApiResult<RemoveAdminsResponse>> BulkDeleteAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/disable", "bulk_disable_admins")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/enable", "bulk_enable_admins")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkEnableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/reset", "bulk_reset_admins_usage")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkResetAdminsUsageAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admins/bulk/users", "bulk_remove_all_users")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkRemoveAllUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/users/activate", "bulk_activate_all_disabled_users")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkActivateAllDisabledUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/admins/bulk/users/disable", "bulk_disable_all_active_users")]
    Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAllActiveUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admins/simple", "get_admins_simple")]
    Task<ApiResult<AdminsSimpleResponse>> GetAdminsSimpleAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, string? search = null, long? offset = null, long? limit = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
