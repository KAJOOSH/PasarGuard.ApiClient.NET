using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IAdminRolesClient
{
    [ApiEndpoint("POST", "/api/admin-role", "create_role")]
    Task<ApiResult<AdminRoleResponse>> CreateRoleAsync(AdminRoleCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/admin-role/{role_id}", "delete_role")]
    Task<ApiResult> DeleteRoleAsync(long roleId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin-role/{role_id}", "get_role")]
    Task<ApiResult<AdminRoleResponse>> GetRoleAsync(long roleId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/admin-role/{role_id}", "modify_role")]
    Task<ApiResult<AdminRoleResponse>> ModifyRoleAsync(long roleId, AdminRoleModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin-roles", "get_roles")]
    Task<ApiResult<AdminRolesResponse>> GetRolesAsync(string? search = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/admin-roles/simple", "get_roles_simple")]
    Task<ApiResult<AdminRolesSimpleResponse>> GetRolesSimpleAsync(CancellationToken cancellationToken = default);
}
