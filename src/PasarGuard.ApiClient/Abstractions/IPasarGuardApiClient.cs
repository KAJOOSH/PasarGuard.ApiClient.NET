namespace PasarGuard.ApiClient.Abstractions;

public interface IPasarGuardApiClient
{
    IDefaultClient Default { get; }
    IAdminClient Admin { get; }
    ISystemClient System { get; }
    ISettingsClient Settings { get; }
    IGroupsClient Groups { get; }
    ICoreClient Core { get; }
    IClientTemplateClient ClientTemplate { get; }
    IHostClient Host { get; }
    INodeClient Node { get; }
    IUserClient User { get; }
    ISubscriptionClient Subscription { get; }
    IUserTemplateClient UserTemplate { get; }
}
