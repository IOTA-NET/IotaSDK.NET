using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MintNft
{
    internal class MintNftsCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public MintNftsCommand(IntPtr walletHandle, int accountIndex, List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions, IMediator mediator) : base(walletHandle, accountIndex)
        {
            NftOptionsList = nftOptionsList;
            TransactionOptions = transactionOptions;
            Mediator = mediator;
        }

        public List<NftOptions> NftOptionsList { get; }
        public TransactionOptions? TransactionOptions { get; }
        public IMediator Mediator { get; }
    }
}
