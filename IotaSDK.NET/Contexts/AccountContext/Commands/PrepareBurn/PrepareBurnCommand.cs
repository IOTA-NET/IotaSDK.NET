using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn
{
    internal class PrepareBurnCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareBurnCommand(IntPtr walletHandle, int accountIndex, BurnIds burnIds, TransactionOptions? transactionOptions) : base(walletHandle, accountIndex)
        {
            BurnIds = burnIds;
            TransactionOptions = transactionOptions;
        }

        public BurnIds BurnIds { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
