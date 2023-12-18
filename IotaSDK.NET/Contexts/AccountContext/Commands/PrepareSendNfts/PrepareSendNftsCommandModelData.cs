using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts
{
    internal class PrepareSendNftsCommandModelData
    {
        public PrepareSendNftsCommandModelData(List<AddressAndNftId> @params, TransactionOptions? options)
        {
            Params = @params;
            Options = options;
        }

        public List<AddressAndNftId> Params { get; }
        public TransactionOptions? Options { get; }
    }

}
