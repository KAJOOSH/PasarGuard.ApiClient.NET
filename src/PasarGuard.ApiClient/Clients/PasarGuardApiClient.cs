using PasarGuard.ApiClient.Abstractions;

namespace PasarGuard.ApiClient.Clients;

public sealed class PasarGuardApiClient : IPasarGuardApiClient
{
    public PasarGuardApiClient(IAdminClient admin, IAdminRolesClient adminRoles, IApiKeysClient apiKeys, IClientTemplateClient clientTemplate, ICoreClient core, IDefaultClient defaultValue, IGroupsClient groups, IHostClient host, INodeClient node, ISettingsClient settings, ISetupClient setup, ISubscriptionClient subscription, ISystemClient system, IUserClient user, IUserHwidClient userHwid, IUserTemplateClient userTemplate)
    {
        Admin = admin;
        AdminRoles = adminRoles;
        ApiKeys = apiKeys;
        ClientTemplate = clientTemplate;
        Core = core;
        Default = defaultValue;
        Groups = groups;
        Host = host;
        Node = node;
        Settings = settings;
        Setup = setup;
        Subscription = subscription;
        System = system;
        User = user;
        UserHwid = userHwid;
        UserTemplate = userTemplate;
    }

    public IAdminClient Admin { get; }

    public IAdminRolesClient AdminRoles { get; }

    public IApiKeysClient ApiKeys { get; }

    public IClientTemplateClient ClientTemplate { get; }

    public ICoreClient Core { get; }

    public IDefaultClient Default { get; }

    public IGroupsClient Groups { get; }

    public IHostClient Host { get; }

    public INodeClient Node { get; }

    public ISettingsClient Settings { get; }

    public ISetupClient Setup { get; }

    public ISubscriptionClient Subscription { get; }

    public ISystemClient System { get; }

    public IUserClient User { get; }

    public IUserHwidClient UserHwid { get; }

    public IUserTemplateClient UserTemplate { get; }
}
