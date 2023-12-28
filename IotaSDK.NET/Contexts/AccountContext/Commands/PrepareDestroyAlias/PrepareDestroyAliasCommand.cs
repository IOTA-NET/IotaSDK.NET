using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias
{
    internal class PrepareDestroyAliasCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareDestroyAliasCommand(IntPtr walletHandle, int accountIndex, string aliasId, TransactionOptions? transactionOptions=null) 
            : base(walletHandle, accountIndex)
        {
            AliasId = aliasId;
            TransactionOptions = transactionOptions;
        }
        public string AliasId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
