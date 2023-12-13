using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StartBackgroundSync
{
    internal class StartBackgroundSyncCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public StartBackgroundSyncCommand(IntPtr walletHandle, SyncOptions? syncOptions = null, ulong? intervalInMilliseconds = null) : base(walletHandle)
        {
            SyncOptions = syncOptions;
            IntervalInMilliseconds = intervalInMilliseconds;
        }

        public SyncOptions? SyncOptions { get; set; }
        public ulong? IntervalInMilliseconds { get; set; }
    }
}
