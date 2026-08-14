using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Authentication;
using PasarGuard.ApiClient.Configuration;
using PasarGuard.ApiClient.DependencyInjection;

namespace PasarGuard.ApiClient.Tests;

public sealed class DependencyInjectionTests
{
    [Fact]
    public async Task RegistrationResolvesEveryClientAndInitialToken()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddPasarGuardApiClient(options =>
        {
            options.BaseUrl = "https://pasarguard.test";
            options.BearerToken = "configured-token";
        });

        await using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IPasarGuardApiClient>();
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();

        Assert.NotNull(client.Admin);
        Assert.NotNull(client.AdminRoles);
        Assert.NotNull(client.ApiKeys);
        Assert.NotNull(client.ClientTemplate);
        Assert.NotNull(client.Core);
        Assert.NotNull(client.Default);
        Assert.NotNull(client.Groups);
        Assert.NotNull(client.Host);
        Assert.NotNull(client.Node);
        Assert.NotNull(client.Settings);
        Assert.NotNull(client.Setup);
        Assert.NotNull(client.Subscription);
        Assert.NotNull(client.System);
        Assert.NotNull(client.User);
        Assert.NotNull(client.UserHwid);
        Assert.NotNull(client.UserTemplate);
        Assert.Equal("configured-token", await tokenProvider.GetTokenAsync());
    }

    [Theory]
    [InlineData("")]
    [InlineData("not-a-url")]
    [InlineData("ftp://pasarguard.test")]
    public void InvalidBaseUrlIsRejected(string baseUrl)
    {
        var options = new PasarGuardClientOptions { BaseUrl = baseUrl };
        Assert.Throws<InvalidOperationException>(options.Validate);
    }

    [Fact]
    public void ConfigurationSectionCanBeRegisteredDirectly()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["PasarGuardClient:BaseUrl"] = "https://pasarguard.test",
                ["PasarGuardClient:TimeoutSeconds"] = "30"
            })
            .Build();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddPasarGuardApiClient(configuration.GetSection("PasarGuardClient"));

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IPasarGuardApiClient>();

        Assert.NotNull(client.Default);
    }
}
