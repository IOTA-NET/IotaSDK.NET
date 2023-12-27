using IotaSDK.NET.Common.Serializers;
using IotaSDK.NET.Domain.Transactions;
using Newtonsoft.Json;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNativeTokens
{
    internal class PrepareMintNativeTokensCommandModelData
    {

        public PrepareMintNativeTokensCommandModelData(string tokenId, BigInteger mintAmount, TransactionOptions? options = null)
        {
            TokenId = tokenId;
            MintAmount = mintAmount;
            Options = options;
        }

        public string TokenId { get; }

        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger MintAmount { get; }

        public TransactionOptions? Options { get; }
    }
}
