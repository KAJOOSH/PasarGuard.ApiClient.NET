# PasarGuard.ApiClient

[![NuGet](https://img.shields.io/nuget/v/PasarGuard.ApiClient.svg)](https://www.nuget.org/packages/PasarGuard.ApiClient)
[![NuGet downloads](https://img.shields.io/nuget/dt/PasarGuard.ApiClient.svg)](https://www.nuget.org/packages/PasarGuard.ApiClient)
[![CI](https://github.com/KAJOOSH/PasarGuard.ApiClient.NET/actions/workflows/ci.yml/badge.svg)](https://github.com/KAJOOSH/PasarGuard.ApiClient.NET/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

PasarGuard.ApiClient is a strongly typed, asynchronous .NET client for PasarGuardAPI. It provides dependency-injection integration, bearer-token authentication, typed request and response models, structured error handling, response headers, and cancellation support across the complete PasarGuardAPI `5.2.1` surface.

## Requirements

- .NET 10 or later
- A PasarGuardAPI `5.2.1` instance

## Installation

Install the package from [NuGet.org](https://www.nuget.org/packages/PasarGuard.ApiClient):

```shell
dotnet add package PasarGuard.ApiClient
```

Or add it directly to your project:

```xml
<PackageReference Include="PasarGuard.ApiClient" Version="5.2.2" />
```

## Configuration

Add the client settings to `appsettings.json`:

```json
{
  "PasarGuardClient": {
    "BaseUrl": "https://pasarguard.example:8000",
    "TimeoutSeconds": 100,
    "BearerToken": "",
    "AuthorizationScheme": "Bearer"
  }
}
```

Register the client with the application configuration:

```csharp
using PasarGuard.ApiClient.DependencyInjection;

builder.Services.AddPasarGuardApiClient(builder.Configuration);
```

Configuration can also be supplied directly:

```csharp
builder.Services.AddPasarGuardApiClient(options =>
{
    options.BaseUrl = "https://pasarguard.example:8000";
    options.TimeoutSeconds = 100;
    options.BearerToken = accessToken;
});
```

## Authentication

Resolve the aggregate client and shared token provider:

```csharp
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Authentication;

var client = serviceProvider.GetRequiredService<IPasarGuardApiClient>();
var tokenProvider = serviceProvider.GetRequiredService<MutableAccessTokenProvider>();
```

Obtain an admin token and apply it to subsequent requests:

```csharp
using PasarGuard.ApiClient.Models;

var tokenResult = await client.Admin.AdminTokenAsync(new BodyAdminToken
{
    Username = username,
    Password = password
});

if (!tokenResult.IsSuccess || tokenResult.Value is null)
{
    throw new InvalidOperationException(tokenResult.Error?.Message);
}

tokenProvider.SetToken(tokenResult.Value.AccessToken);
```

For applications that already manage credentials, register a custom `IAccessTokenProvider` before calling `AddPasarGuardApiClient`.

## Usage

All operations are asynchronous and return `ApiResult` or `ApiResult<T>`.

```csharp
var result = await client.User.GetUsersAsync(limit: 20, cancellationToken: cancellationToken);

if (result.IsSuccess)
{
    foreach (var user in result.Value?.Users ?? [])
    {
        Console.WriteLine(user.Username);
    }
}
else
{
    Console.WriteLine($"Request failed with status {(int)result.StatusCode}: {result.Error?.Message}");
}
```

Create an API key:

```csharp
var result = await client.ApiKeys.CreateApiKeyAsync(new APIKeyCreate
{
    Name = "automation",
    InheritPermissions = true
}, cancellationToken);
```

Read response headers:

```csharp
var result = await client.Subscription.UserSubscriptionHeadersAsync(
    token,
    cancellationToken: cancellationToken);

if (result.Headers.TryGetValue("subscription-userinfo", out var values))
{
    Console.WriteLine(values[0]);
}
```

Each result exposes:

- `IsSuccess` for success detection
- `StatusCode` for the HTTP status
- `Value` for typed response data
- `Error` for HTTP, transport, and serialization failures
- `Headers` for response and content headers

## API areas

The aggregate `IPasarGuardApiClient` provides access to the following clients:

| Property | Area |
| --- | --- |
| `Admin` | Admin authentication and management |
| `AdminRoles` | Admin roles and permissions |
| `ApiKeys` | API key lifecycle |
| `ClientTemplate` | Client templates |
| `Core` | Core configurations and Reality scanning |
| `Default` | Root and health endpoints |
| `Groups` | User groups |
| `Host` | Hosts |
| `Node` | Nodes, status, latency, and metrics |
| `Settings` | Server settings |
| `Setup` | Owner setup and upgrade |
| `Subscription` | Subscription output and headers |
| `System` | System, resource, and WireGuard statistics |
| `User` | Users and bulk operations |
| `UserHwid` | User HWID management |
| `UserTemplate` | User templates |

Individual clients such as `IUserClient` or `INodeClient` can also be resolved directly through dependency injection.

## Compatibility

Each package release identifies its supported PasarGuardAPI version. Applications should keep the client and server versions aligned when endpoint contracts or data models change.

## Versioning

Package versions follow [Semantic Versioning](https://semver.org/). The supported PasarGuardAPI version is stated in the package description and release notes.

## License

PasarGuard.ApiClient is available under the [MIT License](LICENSE).
