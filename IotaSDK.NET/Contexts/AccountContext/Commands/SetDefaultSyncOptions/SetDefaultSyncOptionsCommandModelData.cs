using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetDefaultSyncOptions
{
    internal class SetDefaultSyncOptionsCommandModelData
    {
        public SetDefaultSyncOptionsCommandModelData(SyncOptions options)
        {
            Options = options;
        }

        public SyncOptions Options { get; }
    }
}
