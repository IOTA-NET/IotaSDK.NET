using IotaSDK.NET.Common.Serializers;
using Newtonsoft.Json;
using System.Numerics;

namespace IotaSDK.NET.Domain.Accounts
{
    public class NativeTokenBalance
    {
        public NativeTokenBalance(string tokenId, BigInteger total, BigInteger available, string? metadata)
        {
            TokenId = tokenId;
            Total = total;
            Available = available;
            Metadata = metadata;
        }

        /// <summary>
        /// Hexencoded native token id
        /// </summary>
        public string TokenId { get; set; }

        /// <summary>
        /// The total native token balance
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger Total { get; }

        /// <summary>
        /// The available amount of the total native token balance
        /// </summary>
        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger Available { get; }

        /// <summary>
        /// Some metadata of the native token
        /// </summary>
        public string? Metadata { get; }
    }
}
