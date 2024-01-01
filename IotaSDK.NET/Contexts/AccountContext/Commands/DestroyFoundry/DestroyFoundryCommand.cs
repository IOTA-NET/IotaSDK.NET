using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.DestroyFoundry
{
    internal class DestroyFoundryCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public DestroyFoundryCommand(IntPtr walletHandle, int accountIndex, string foundryId, TransactionOptions? transactionOptions=null) : base(walletHandle, accountIndex)
        {
            FoundryId = foundryId;
            TransactionOptions = transactionOptions;
        }

        public string FoundryId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
