using IotaSDK.NET.Common.Serializers;
using IotaSDK.NET.Domain.Transactions;
using Newtonsoft.Json;
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


        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger MeltAmount { get; }
        public TransactionOptions? Options { get; }
    }
}
