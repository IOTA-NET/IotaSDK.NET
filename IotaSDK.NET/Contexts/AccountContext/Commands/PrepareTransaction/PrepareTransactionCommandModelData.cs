using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareTransaction
{
    internal class PrepareTransactionCommandModelData
    {
        public PrepareTransactionCommandModelData(List<Output> outputs, TransactionOptions? options=null)
        {
            Outputs = outputs;
            Options = options;
        }

        public List<Output> Outputs { get; }
        public TransactionOptions? Options { get; }
    }
}


