using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts
{
    internal class PrepareMintNftsCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareMintNftsCommand(IntPtr walletHandle, int accountIndex, List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            NftOptionsList = nftOptionsList;
            TransactionOptions = transactionOptions;
        }

        public List<NftOptions> NftOptionsList { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
