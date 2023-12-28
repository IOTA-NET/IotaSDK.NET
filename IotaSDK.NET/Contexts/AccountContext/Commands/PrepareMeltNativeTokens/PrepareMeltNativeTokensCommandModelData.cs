using IotaSDK.NET.Domain.Transactions;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMeltNativeTokens
{
    internal class PrepareMeltNativeTokensCommandModelData
    {
        public PrepareMeltNativeTokensCommandModelData(string tokenId, BigInteger meltAmount, TransactionOptions? options)
        {
            TokenId = tokenId;
            MeltAmount = meltAmount;
            Options = options;
        }

        public string TokenId { get; }
        public BigInteger MeltAmount { get; }
        public TransactionOptions? Options { get; }
    }
}
