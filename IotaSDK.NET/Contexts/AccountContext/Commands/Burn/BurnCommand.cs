using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Burn
{
    internal class BurnCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public BurnCommand(IntPtr walletHandle, int accountIndex, BurnIds burnIds, TransactionOptions? transactionOptions, IMediator mediator) 
            : base(walletHandle, accountIndex)
        {
            BurnIds = burnIds;
            TransactionOptions = transactionOptions;
            Mediator = mediator;
        }

        public BurnIds BurnIds { get; }
        public TransactionOptions? TransactionOptions { get; }
        public IMediator Mediator { get; }
    }
}
