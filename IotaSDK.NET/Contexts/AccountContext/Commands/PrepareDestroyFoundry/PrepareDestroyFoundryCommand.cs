using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyFoundry
{
    internal class PrepareDestroyFoundryCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareDestroyFoundryCommand(IntPtr walletHandle, int accountIndex, string foundryId, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            FoundryId = foundryId;
            TransactionOptions = transactionOptions;
        }

        public string FoundryId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
