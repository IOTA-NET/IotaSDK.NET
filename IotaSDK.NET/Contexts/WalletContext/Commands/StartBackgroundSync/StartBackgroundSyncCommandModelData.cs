using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StartBackgroundSync
{
    internal class StartBackgroundSyncCommandModelData
    {
        public StartBackgroundSyncCommandModelData(SyncOptions? syncOptions = null, ulong? intervalInMilliseconds = null)
        {
            Options = syncOptions;
            IntervalInMilliseconds = intervalInMilliseconds;
        }
        public SyncOptions? Options { get; set; }
        public ulong? IntervalInMilliseconds { get; set; }
    }
}
