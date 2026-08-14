
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Authentication;
using PasarGuard.ApiClient.DependencyInjection;
using PasarGuard.ApiClient.Models;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());
services.AddPasarGuardApiClient(configuration);

using var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IPasarGuardApiClient>();
var tokenProvider = provider.GetRequiredService<MutableAccessTokenProvider>();

var health = await client.Default.HealthAsync();

if (health.IsSuccess)
{
    Console.WriteLine($"Health response: {health.StatusCode}");
}
else
{
    Console.WriteLine($"Error: {health.Error?.Message}");
}

var tokenResult = await client.Admin.AdminTokenAsync(new BodyAdminToken
{
    Username = "",
    Password = ""
});

if (!tokenResult.IsSuccess || tokenResult.Value is null)
{
    return;
}

tokenProvider.SetToken(tokenResult.Value.AccessToken);

var admins = await client.Admin.GetAdminsAsync(limit: 20);

if (!admins.IsSuccess)
{
    Console.WriteLine(admins.Error?.Message);
}
