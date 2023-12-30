using IotaSDK.NET.Domain.Tokens;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Options.PrepareOutput
{
    /// <summary>
    /// Assets to include in the output
    /// </summary>
    public class PrepareOutputAssetOptions
    {
        public PrepareOutputAssetOptions(List<NativeToken>? nativeTokens, string? nftId)
        {
            NativeTokens = nativeTokens;
            NftId = nftId;
        }

        /// <summary>
        /// Native Token assets to include
        /// </summary>
        public List<NativeToken>? NativeTokens { get; }

        /// <summary>
        /// The NFT to include
        /// </summary>
        public string? NftId { get; }
    }
}
