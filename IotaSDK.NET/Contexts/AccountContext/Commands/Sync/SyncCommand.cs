using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Sync
{
    internal class SyncCommand : AccountRequest<IotaSDKResponse<AccountBalance>>
    {
        public SyncCommand(IntPtr walletHandle, int accountIndex, SyncOptions? syncOptions = null) : base(walletHandle, accountIndex)
        {
            SyncOptions = syncOptions;
        }

        public SyncOptions? SyncOptions { get; }
    }
}
