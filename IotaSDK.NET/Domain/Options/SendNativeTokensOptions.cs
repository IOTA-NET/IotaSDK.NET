using IotaSDK.NET.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace IotaSDK.NET.Domain.Options
{
    public class SendNativeTokensOptions
    {
        public SendNativeTokensOptions(string address, List<KeyValuePair<string, ulong>> nativeTokens, string? returnAddress=null, ulong? expiration=null)
        {
            Address = address;
            ReturnAddress = returnAddress;
            Expiration = expiration;
            NativeTokens = nativeTokens.Select(keyValuePair => new List<string> { keyValuePair.Key, keyValuePair.Value.ToHex()}).ToList();
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
        /// The Native Tokens to send, token id to amount mapping
        /// </summary>
        public List<List<string>> NativeTokens { get; }
    }
}
