using System.Collections.Generic;
using System.Numerics;

namespace IotaSDK.NET.Domain.Options
{
    public class SendNativeTokensOptions
    {
        public SendNativeTokensOptions(string address, List<(string tokenId, BigInteger amount)> nativeTokens, string? returnAddress=null, ulong? expiration=null)
        {
            Address = address;
            ReturnAddress = returnAddress;
            Expiration = expiration;
            NativeTokens = nativeTokens;
        }

        /// <summary>
        /// The Bech32 address of the receiver.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Bech32 encoded address, to which the storage deposit will be returned.
        /// Default will use the first address of the account.
        /// </summary>
        public string? ReturnAddress { get; }

        /// <summary>
        /// Expiration in seconds, after which the output will be available for the sender again, 
        /// if not spent by the receiver before. Default is 1 day.
        /// </summary>
        public ulong? Expiration { get; }

        /// <summary>
        /// The Native Tokens to send
        /// </summary>
        public List<(string tokenId, BigInteger amount)> NativeTokens { get; }
    }
}
