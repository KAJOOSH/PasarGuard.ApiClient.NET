using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISettingsClient
{
    Task<ApiResult<SettingsSchemaOutput>> GetSettingsAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<SettingsSchemaOutput>> ModifySettingsAsync(SettingsSchemaInput request, CancellationToken cancellationToken = default);

    Task<ApiResult<General>> GetGeneralSettingsAsync(CancellationToken cancellationToken = default);
}
