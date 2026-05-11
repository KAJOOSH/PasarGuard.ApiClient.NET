using PasarGuard.ApiClient.Abstractions;

namespace PasarGuard.ApiClient.Clients;

public sealed class PasarGuardApiClient : IPasarGuardApiClient
{
    public PasarGuardApiClient(IDefaultClient defaultValue, IAdminClient admin, ISystemClient system, ISettingsClient settings, IGroupsClient groups, ICoreClient core, IClientTemplateClient clientTemplate, IHostClient host, INodeClient node, IUserClient user, ISubscriptionClient subscription, IUserTemplateClient userTemplate)
    {
        Default = defaultValue;
        Admin = admin;
        System = system;
        Settings = settings;
        Groups = groups;
        Core = core;
        ClientTemplate = clientTemplate;
        Host = host;
        Node = node;
        User = user;
        Subscription = subscription;
        UserTemplate = userTemplate;
    }

    public IDefaultClient Default { get; }
    public IAdminClient Admin { get; }
    public ISystemClient System { get; }
    public ISettingsClient Settings { get; }
    public IGroupsClient Groups { get; }
    public ICoreClient Core { get; }
    public IClientTemplateClient ClientTemplate { get; }
    public IHostClient Host { get; }
    public INodeClient Node { get; }
    public IUserClient User { get; }
    public ISubscriptionClient Subscription { get; }
    public IUserTemplateClient UserTemplate { get; }
}
