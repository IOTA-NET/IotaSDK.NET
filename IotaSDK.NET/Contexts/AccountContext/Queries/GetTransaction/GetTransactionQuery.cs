using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetTransaction
{
    internal class GetTransactionQuery : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public GetTransactionQuery(IntPtr walletHandle, int accountIndex, string transactionId) : base(walletHandle, accountIndex)
        {
            TransactionId = transactionId;
        }

        public string TransactionId { get; }
    }
}
