﻿using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts;
using IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MintNfts
{
    internal class MintNftsCommandHandler : IRequestHandler<MintNftsCommand, IotaSDKResponse<Transaction>>
    {
        public async Task<IotaSDKResponse<Transaction>> Handle(MintNftsCommand request, CancellationToken cancellationToken)
        {
            IotaSDKResponse<PreparedTransactionData> prepareMintNftsResponse = await request.Mediator.Send(new PrepareMintNftsCommand(request.WalletHandle, request.AccountIndex, request.NftOptionsList, request.TransactionOptions));
            PreparedTransactionData preparedTransactionData = prepareMintNftsResponse.Payload;
            return await request.Mediator.Send(new SignAndSubmitTransactionCommand(request.WalletHandle, request.AccountIndex, preparedTransactionData));
        }
    }
}
