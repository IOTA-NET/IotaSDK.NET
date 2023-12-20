using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareTransaction
{
    internal class PrepareTransactionCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareTransactionCommand(
                IntPtr walletHandle, int accountIndex, 
                List<Output> outputs, TransactionOptions? transactionOptions=null
            ) 
            : base(walletHandle, accountIndex)
        {
            Outputs = outputs;
            TransactionOptions = transactionOptions;
        }

        public List<Output> Outputs { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}


