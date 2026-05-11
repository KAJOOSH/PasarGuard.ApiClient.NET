using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISystemClient
{
    Task<ApiResult<SystemStats>> GetSystemStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default);

    Task<ApiResult<List<string>>> GetInboundsAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<List<InboundSummary>>> GetInboundDetailsAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<WorkersHealth>> GetWorkersHealthAsync(CancellationToken cancellationToken = default);
}
