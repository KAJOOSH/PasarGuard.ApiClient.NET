
# PasarGuard API Client برای .NET 8

این پروژه یک کلاینت typed برای PasarGuardAPI است که از روی فایل `openapi.json` تولید شده است.

## محتوا

- کتابخانه اصلی: `src/PasarGuard.ApiClient`
- نمونه Console App: `samples/PasarGuard.ApiClient.ConsoleSample`
- تعداد endpoint های تولیدشده: `173`
- تعداد schema/model های تولیدشده: `191`

## ساختار پروژه

```text
PasarGuardApiClient/
├── src/
│   └── PasarGuard.ApiClient/
│       ├── Abstractions/
│       ├── Authentication/
│       ├── Clients/
│       ├── Configuration/
│       ├── Core/
│       ├── DependencyInjection/
│       ├── Internal/
│       ├── Models/
│       └── Serialization/
├── samples/
│   └── PasarGuard.ApiClient.ConsoleSample/
├── openapi/
│   └── openapi.json
└── PasarGuardApiClient.sln
```

## کلاینت‌های تولیدشده

- `DefaultClient`: 2 متد
- `AdminClient`: 34 متد
- `SystemClient`: 4 متد
- `SettingsClient`: 3 متد
- `GroupsClient`: 11 متد
- `CoreClient`: 8 متد
- `ClientTemplateClient`: 7 متد
- `HostClient`: 9 متد
- `NodeClient`: 29 متد
- `UserClient`: 52 متد
- `SubscriptionClient`: 5 متد
- `UserTemplateClient`: 9 متد

## تنظیمات

فایل `appsettings.json` نمونه:

```json
{
  "PasarGuardClient": {
    "BaseUrl": "https://your-pasarguard-host.example",
    "TimeoutSeconds": 100,
    "BearerToken": "",
    "AuthorizationScheme": "Bearer"
  }
}
```

`BaseUrl`، `TimeoutSeconds` و Bearer Token از تنظیمات خوانده می‌شوند. اگر `BearerToken` خالی باشد، هدر Authorization ارسال نمی‌شود.

## ثبت در Dependency Injection

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());
services.AddPasarGuardApiClient(configuration);

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IPasarGuardApiClient>();
```

## نمونه استفاده

```csharp
var health = await client.Default.HealthAsync(cancellationToken: CancellationToken.None);

if (health.IsSuccess)
{
    Console.WriteLine(health.Value);
}
else
{
    Console.WriteLine(health.Error?.Message);
}
```

نمونه دریافت token ادمین:

```csharp
using PasarGuard.ApiClient.Models;

var tokenResult = await client.Admin.AdminTokenAsync(new BodyAdminTokenApiAdminTokenPost
{
    Username = "admin",
    Password = "password"
});

if (tokenResult.IsSuccess)
{
    Console.WriteLine(tokenResult.Value?.AccessToken);
}
```

نمونه فراخوانی یک endpoint دارای Authorization:

```csharp
var admins = await client.Admin.GetAdminsAsync(limit: 20);

if (!admins.IsSuccess)
{
    Console.WriteLine(admins.Error?.Message);
}
```

## مدیریت خطا

تمام متدها خروجی استاندارد `ApiResult` یا `ApiResult<T>` دارند. خطاهای HTTP مثل `400`، `401`، `403`، `404`، `409`، `422` و خطاهای سرور به `ApiError` تبدیل می‌شوند.

```csharp
var result = await client.User.GetUserAsync("username");

if (!result.IsSuccess)
{
    Console.WriteLine(result.StatusCode);
    Console.WriteLine(result.Error?.Type);
    Console.WriteLine(result.Error?.Message);
}
```

## Build و Run

از ریشه پروژه:

```bash
dotnet build PasarGuardApiClient.sln
```

اجرای نمونه Console:

```bash
cd samples/PasarGuard.ApiClient.ConsoleSample
dotnet run
```

قبل از اجرا مقدار `PasarGuardClient:BaseUrl` و در صورت نیاز `PasarGuardClient:BearerToken` را تنظیم کنید.

## نکات طراحی

- Target Framework برابر `net8.0` است.
- از `HttpClientFactory` استفاده شده است.
- تمام client ها از DI تزریق می‌شوند.
- serialization با `System.Text.Json` انجام می‌شود.
- تمام متدهای endpoint ها async هستند و `CancellationToken` دریافت می‌کنند.
- مدل‌ها و enum ها با `JsonPropertyName` و `EnumMember` با نام‌های OpenAPI هماهنگ شده‌اند.
- کدهای کتابخانه کامنت ندارند.
