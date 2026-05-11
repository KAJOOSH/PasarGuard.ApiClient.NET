using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IAdminClient
{
    Task<ApiResult<Token>> AdminTokenAsync(BodyAdminTokenApiAdminTokenPost request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> AdminMiniAppTokenAsync(string xTelegramAuthorization, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> GetCurrentAdminAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> CreateAdminAsync(AdminCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ModifyAdminAsync(string username, AdminModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveAdminAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ModifyAdminByUsernameAsync(string username, AdminModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveAdminByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ModifyAdminByIdAsync(long adminId, AdminModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveAdminByIdAsync(long adminId, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminsResponse>> GetAdminsAsync(string? username = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminsSimpleResponse>> GetAdminsSimpleAsync(string? search = null, long? offset = null, long? limit = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetAdminUsageAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetAdminUsageByUsernameAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetAdminUsageByIdAsync(long adminId, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> DisableAllActiveUsersAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> DisableAllActiveUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> DisableAllActiveUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> RemoveAllUsersAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> RemoveAllUsersByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> RemoveAllUsersByIdAsync(long adminId, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ResetAdminUsageAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ResetAdminUsageByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<AdminDetails>> ResetAdminUsageByIdAsync(long adminId, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveAdminsResponse>> BulkDeleteAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkResetAdminsUsageAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkEnableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAllActiveUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkActivateAllDisabledUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkAdminsActionResponse>> BulkRemoveAllUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default);
}
