using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts
{
    internal class PrepareMintNftsCommandModelData
    {
        public PrepareMintNftsCommandModelData(List<NftOptions> nftOptionsList, TransactionOptions? transactionOptions = null)
        {
            Params = nftOptionsList;
            Options = transactionOptions;
        }

        public List<NftOptions> Params { get; }
        public TransactionOptions? Options { get; }
    }
}
