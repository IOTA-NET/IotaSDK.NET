using IotaSDK.NET.Common.Extensions;

namespace IotaSDK.NET.Domain.Options
{
    /// <summary>
    /// Options for creating Native Tokens.
    /// </summary>
    public class NativeTokenCreationOptions
    {
        public NativeTokenCreationOptions(string? aliasId, ulong circulatingSupply, ulong maximumSupply, string? foundryMetadataJson)
        {
            AliasId = aliasId;
            CirculatingSupply = circulatingSupply.ToHex();
            MaximumSupply = maximumSupply.ToHex();

            if(foundryMetadataJson != null)
                FoundryMetadata = foundryMetadataJson.ToHexString();
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
