using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
        ArgumentNullException.ThrowIfNull(configuration);
        return services.AddPasarGuardApiClient(configuration.GetSection(sectionName));
    }

    public static IServiceCollection AddPasarGuardApiClient(this IServiceCollection services, IConfigurationSection configurationSection)
    {
        ArgumentNullException.ThrowIfNull(configurationSection);
        services.AddOptions<PasarGuardClientOptions>()
            .Bind(configurationSection)
            .Validate(ValidateOptions)
            .ValidateOnStart();
        return AddServices(services);
    }

    public static IServiceCollection AddPasarGuardApiClient(this IServiceCollection services, Action<PasarGuardClientOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        services.AddOptions<PasarGuardClientOptions>()
            .Configure(configure)
            .Validate(ValidateOptions)
            .ValidateOnStart();
        return AddServices(services);
    }

    private static IServiceCollection AddServices(IServiceCollection services)
    {
        services.TryAddSingleton<MutableAccessTokenProvider>();
        services.TryAddSingleton<IAccessTokenProvider>(serviceProvider => serviceProvider.GetRequiredService<MutableAccessTokenProvider>());
        services.AddTransient<BearerTokenHandler>();
        services.AddHttpClient(PasarGuardClientOptions.HttpClientName, ConfigureHttpClient)
            .AddHttpMessageHandler<BearerTokenHandler>();

        AddClient<IAdminClient, AdminClient>(services);
        AddClient<IAdminRolesClient, AdminRolesClient>(services);
        AddClient<IApiKeysClient, ApiKeysClient>(services);
        AddClient<IClientTemplateClient, ClientTemplateClient>(services);
        AddClient<ICoreClient, CoreClient>(services);
        AddClient<IDefaultClient, DefaultClient>(services);
        AddClient<IGroupsClient, GroupsClient>(services);
        AddClient<IHostClient, HostClient>(services);
        AddClient<INodeClient, NodeClient>(services);
        AddClient<ISettingsClient, SettingsClient>(services);
        AddClient<ISetupClient, SetupClient>(services);
        AddClient<ISubscriptionClient, SubscriptionClient>(services);
        AddClient<ISystemClient, SystemClient>(services);
        AddClient<IUserClient, UserClient>(services);
        AddClient<IUserHwidClient, UserHwidClient>(services);
        AddClient<IUserTemplateClient, UserTemplateClient>(services);
        services.AddTransient<IPasarGuardApiClient, PasarGuardApiClient>();
        return services;
    }

    private static void AddClient<TService, TImplementation>(IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.AddTransient<TService>(serviceProvider =>
        {
            var httpClient = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient(PasarGuardClientOptions.HttpClientName);
            return ActivatorUtilities.CreateInstance<TImplementation>(serviceProvider, httpClient);
        });
    }

    private static void ConfigureHttpClient(IServiceProvider serviceProvider, HttpClient httpClient)
    {
        var options = serviceProvider.GetRequiredService<IOptions<PasarGuardClientOptions>>().Value;
        options.Validate();
        httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
    }

    private static bool ValidateOptions(PasarGuardClientOptions options)
    {
        try
        {
            options.Validate();
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
