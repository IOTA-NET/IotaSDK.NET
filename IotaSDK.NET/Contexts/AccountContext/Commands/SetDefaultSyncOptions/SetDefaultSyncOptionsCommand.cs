using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetDefaultSyncOptions
{
    internal class SetDefaultSyncOptionsCommand : AccountRequest
    {
        public SetDefaultSyncOptionsCommand(IntPtr walletHandle, int accountIndex, SyncOptions syncOptions) : base(walletHandle, accountIndex)
        {
            SyncOptions = syncOptions;
        }

        public SyncOptions SyncOptions { get; }
    }
}


