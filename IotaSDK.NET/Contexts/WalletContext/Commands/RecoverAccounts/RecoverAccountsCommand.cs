using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.WalletContext.Commands.RestoreBackup;
using IotaSDK.NET.Domain.Accounts;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.RecoverAccounts
{
    internal class RecoverAccountsCommand : WalletRequest<IotaSDKResponse<List<AccountMeta>>>
    {
        public RecoverAccountsCommand(IntPtr walletHandle, int accountStartIndex, int accountGapLimit, int addressGapLimit, SyncOptions syncOptions) : base(walletHandle)
        {
            AccountStartIndex = accountStartIndex;
            AccountGapLimit = accountGapLimit;
            AddressGapLimit = addressGapLimit;
            SyncOptions = syncOptions;
        }

        public int AccountStartIndex { get; }
        public int AccountGapLimit { get; }
        public int AddressGapLimit { get; }
        public SyncOptions SyncOptions { get; }
    }
}
