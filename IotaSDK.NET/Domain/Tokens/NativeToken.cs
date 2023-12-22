using IotaSDK.NET.Common.Extensions;
using Newtonsoft.Json;

namespace IotaSDK.NET.Domain.Tokens
{
    public class NativeToken
    {
        [JsonConstructor]

        public NativeToken(string id, string amount)
        {
            Id = id;
            Amount = amount.FromHexToULong();
        }

        /// <summary>
        /// Identifier of the native token.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Amount of native tokens of the given Token ID.
        /// </summary>
        public ulong Amount { get; set; }
    }
}
