using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Authentication;
using PasarGuard.ApiClient.Clients;
using PasarGuard.ApiClient.Configuration;

namespace PasarGuard.ApiClient.DependencyInjection;

public static class PasarGuardServiceCollectionExtensions
{
    public static IServiceCollection AddPasarGuardApiClient(this IServiceCollection services, IConfiguration configuration, string sectionName = PasarGuardClientOptions.SectionName)
    {
        services.Configure<PasarGuardClientOptions>(configuration.GetSection(sectionName));
        services.AddSingleton<MutableAccessTokenProvider>();
        services.AddSingleton<IAccessTokenProvider>(sp => sp.GetRequiredService<MutableAccessTokenProvider>());
        services.AddTransient<BearerTokenHandler>();
        services.AddHttpClient(PasarGuardClientOptions.HttpClientName, (serviceProvider, httpClient) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<PasarGuardClientOptions>>().Value;
            options.Validate();
            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
            httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        }).AddHttpMessageHandler<BearerTokenHandler>();

        services.AddTransient<IDefaultClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<DefaultClient>>();
            return new DefaultClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IAdminClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<AdminClient>>();
            return new AdminClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<ISystemClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<SystemClient>>();
            return new SystemClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<ISettingsClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<SettingsClient>>();
            return new SettingsClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IGroupsClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<GroupsClient>>();
            return new GroupsClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<ICoreClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<CoreClient>>();
            return new CoreClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IClientTemplateClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<ClientTemplateClient>>();
            return new ClientTemplateClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IHostClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<HostClient>>();
            return new HostClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<INodeClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<NodeClient>>();
            return new NodeClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IUserClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<UserClient>>();
            return new UserClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<ISubscriptionClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<SubscriptionClient>>();
            return new SubscriptionClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IUserTemplateClient>(serviceProvider =>
        {
            var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var logger = serviceProvider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<UserTemplateClient>>();
            return new UserTemplateClient(factory.CreateClient(PasarGuardClientOptions.HttpClientName), logger);
        });
        services.AddTransient<IPasarGuardApiClient, PasarGuardApiClient>();
        return services;
    }
}
