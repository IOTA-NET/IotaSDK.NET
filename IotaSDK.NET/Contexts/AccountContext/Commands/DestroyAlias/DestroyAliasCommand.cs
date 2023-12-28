using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.DestroyAlias
{
    internal class DestroyAliasCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public DestroyAliasCommand(IntPtr walletHandle, int accountIndex, string aliasId, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            AliasId = aliasId;
            TransactionOptions = transactionOptions;
            TransactionOptions = transactionOptions;
        }
        public string AliasId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
