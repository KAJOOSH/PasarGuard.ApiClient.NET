namespace PasarGuard.ApiClient.Abstractions;

public interface IPasarGuardApiClient
{
    IAdminClient Admin { get; }
    IAdminRolesClient AdminRoles { get; }
    IApiKeysClient ApiKeys { get; }
    IClientTemplateClient ClientTemplate { get; }
    ICoreClient Core { get; }
    IDefaultClient Default { get; }
    IGroupsClient Groups { get; }
    IHostClient Host { get; }
    INodeClient Node { get; }
    ISettingsClient Settings { get; }
    ISetupClient Setup { get; }
    ISubscriptionClient Subscription { get; }
    ISystemClient System { get; }
    IUserClient User { get; }
    IUserHwidClient UserHwid { get; }
    IUserTemplateClient UserTemplate { get; }
}
