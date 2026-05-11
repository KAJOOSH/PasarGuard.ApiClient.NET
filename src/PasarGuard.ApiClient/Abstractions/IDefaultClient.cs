using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IDefaultClient
{
    Task<ApiResult<string>> BaseAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<Dictionary<string, object?>>> HealthAsync(CancellationToken cancellationToken = default);
}
