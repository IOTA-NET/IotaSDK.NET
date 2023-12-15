using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Sync
{
    internal class SyncCommandModelData
    {
        public SyncCommandModelData(SyncOptions? options)
        {
            Options = options;
        }

        public SyncOptions? Options { get; }
    }
}
