using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class NftOutput : ImmutableFeaturesOutput
    {
        public NftOutput(
            string amount,
            string nftId,
            List<UnlockCondition> unlockConditions,
            List<Feature> immutableFeatures)
            : base(amount, (int)OutputType.Nft, unlockConditions, immutableFeatures)
        {
            NftId = nftId;
        }

        /// <summary>
        /// Unique identifier of the NFT, which is the BLAKE2b-256 hash of the Output ID that created it.
        /// </summary>
        public string NftId { get; }
    }
}
