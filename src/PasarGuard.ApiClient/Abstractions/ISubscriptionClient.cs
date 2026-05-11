using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISubscriptionClient
{
    Task<ApiResult<JsonElement>> UserSubscriptionAsync(string token, string? userAgent = @"", CancellationToken cancellationToken = default);

    Task<ApiResult<SubscriptionUserResponse>> UserSubscriptionInfoAsync(string token, CancellationToken cancellationToken = default);

    Task<ApiResult<List<ApplicationOutput>>> UserSubscriptionAppsAsync(string token, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetSubUserUsageAsync(string token, DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> UserSubscriptionWithClientTypeAsync(string token, ConfigFormat clientType, CancellationToken cancellationToken = default);
}
