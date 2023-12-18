using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Burn
{
    internal class BurnCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public BurnCommand(IntPtr walletHandle, int accountIndex, BurnIds burnIds, TransactionOptions? transactionOptions)
            : base(walletHandle, accountIndex)
        {
            BurnIds = burnIds;
            TransactionOptions = transactionOptions;
        }

        public BurnIds BurnIds { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
