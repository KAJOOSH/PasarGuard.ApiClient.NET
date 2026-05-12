# PasarGuard.ApiClient.NET

A modern, production-ready .NET client SDK for the PasarGuard API.

PasarGuard.ApiClient.NET generates clean, scalable, and fully asynchronous C# API clients from PasarGuard API specifications with support for:

* .NET 10
* HttpClientFactory
* Dependency Injection
* Bearer Token Authentication
* Result Wrappers
* Error Handling
* ILogger
* CancellationToken
* Nullable Reference Types
* Clean Architecture
* Typed API Clients

---

# Features

* Strongly typed request/response models
* Async-first architecture
* Automatic HttpClient configuration
* Production-ready folder structure
* Configurable authentication
* Built-in error handling
* Minimal API / Console examples
* Clean and maintainable generated code

---

# Installation

Clone repository:

```bash
git clone https://github.com/KAJOOSH/PasarGuard.ApiClient.NET.git
```

Restore packages:

```bash
dotnet restore
```

Build solution:

```bash
dotnet build
```

---

# Configuration

appsettings.json

```json
{
  "PasarGuardApi": {
    "BaseUrl": "https://api.example.com",
    "TimeoutSeconds": 30,
    "AuthorizationScheme": "Bearer",
    "BearerToken": ""
  }
}
```

---

# Dependency Injection

```csharp
builder.Services.AddPasarGuardApiClient(
    builder.Configuration.GetSection("PasarGuardApi")
);
```

---

# Authentication

Retrieve token:

```csharp
var tokenResult = await client.Admin.AdminTokenAsync(
    new BodyAdminTokenApiAdminTokenPost
    {
        Username = "admin",
        Password = "password"
    }
);
```

Set token dynamically:

```csharp
tokenProvider.SetToken(tokenResult.Value.AccessToken);
```

---

# Usage Example

```csharp
var users = await client.User.GetUsersAsync(
    offset: 0,
    limit: 20
);

if (users.IsSuccess)
{
    foreach (var user in users.Value?.Users ?? [])
    {
        Console.WriteLine(user.Username);
    }
}
else
{
    Console.WriteLine(users.Error?.Message);
}
```

---

# Project Structure

```text
src/
 ├── PasarGuard.ApiClient/
 │    ├── Authentication/
 │    ├── Clients/
 │    ├── Contracts/
 │    ├── Models/
 │    ├── Options/
 │    ├── Services/
 │    ├── Wrappers/
 │    └── Extensions/

samples/
 └── PasarGuard.ApiClient.ConsoleSample/
```

---

# Technologies

* .NET 10
* C#
* System.Text.Json
* Microsoft.Extensions.Http
* Microsoft.Extensions.Logging

---

# Goals

PasarGuard.ApiClient.NET focuses on generating SDKs that are:

* Clean
* Maintainable
* Extensible
* Production-ready
* Modern
* Developer-friendly

---

# License

MIT License
