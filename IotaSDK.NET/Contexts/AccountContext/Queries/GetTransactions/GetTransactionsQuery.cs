using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetTransactions
{
    internal class GetTransactionsQuery : AccountRequest<IotaSDKResponse<List<Transaction>>>
    {
        public GetTransactionsQuery(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
