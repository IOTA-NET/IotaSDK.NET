using IotaSDK.NET.Common.Serializers;
using Newtonsoft.Json;
using System.Numerics;

namespace IotaSDK.NET.Domain.Tokens
{
    public class NativeToken
    {
        [JsonConstructor]

        public NativeToken(string id, BigInteger amount)
        {
            Id = id;
            Amount = amount;
        }

        /// <summary>
        /// Identifier of the native token.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Amount of native tokens of the given Token ID.
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger Amount { get; set; }
    }
}
