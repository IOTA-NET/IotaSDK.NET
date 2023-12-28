using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Domain.Tokens;
using Newtonsoft.Json;

namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Options for creating Native Tokens.
    /// </summary>
    public class NativeTokenCreationOptions
    {
        public NativeTokenCreationOptions(ulong circulatingSupply, ulong maximumSupply, NativeTokenIrc30? nativeTokenIrc30, string? aliasId = null)
        {
            AliasId = aliasId;
            CirculatingSupply = circulatingSupply.ToHex();
            MaximumSupply = maximumSupply.ToHex();

            if (nativeTokenIrc30 != null)
                FoundryMetadata = JsonConvert.SerializeObject(nativeTokenIrc30).ToHexString();
        }

        /// <summary>
        /// The Alias ID of the corresponding Foundry.
        /// </summary>
        public string? AliasId { get; }
        public string CirculatingSupply { get; }
        public string MaximumSupply { get; }

        /// <summary>
        /// Hex encoded bytes
        /// </summary>
        public string? FoundryMetadata { get; }
    }
}
