using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Serializers;
using Newtonsoft.Json;
using System.Numerics;

namespace IotaSDK.NET.Domain.Tokens
{
    public class SimpleTokenScheme : TokenScheme
    {
        public SimpleTokenScheme(BigInteger mintedTokens, BigInteger meltedTokens, BigInteger maximumSupply)
            : base((int)TokenSchemeType.Simple)
        {
            MintedTokens = mintedTokens;
            MeltedTokens = meltedTokens;
            MaximumSupply = maximumSupply;
        }



        /// <summary>
        /// Amount of tokens minted by this foundry.
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger MintedTokens { get; set; }


        /// <summary>
        /// Amount of tokens melted by this foundry.
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger MeltedTokens { get; set; }


        /// <summary>
        /// Maximum supply of tokens controlled by this foundry.
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger MaximumSupply { get; set; }
    }
}
