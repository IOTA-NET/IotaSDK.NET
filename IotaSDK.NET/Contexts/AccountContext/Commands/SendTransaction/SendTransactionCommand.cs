using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendTransaction
{
    internal class SendTransactionCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SendTransactionCommand(IntPtr walletHandle, int accountIndex, List<Output> outputs, TransactionOptions? transactionOptions) : base(walletHandle, accountIndex)
        {
            Outputs = outputs;
            TransactionOptions = transactionOptions;
        }

        public List<Output> Outputs { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
