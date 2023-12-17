using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public abstract class StateMetadataOutput : ImmutableFeaturesOutput
    {
        protected StateMetadataOutput(
            string amount,
            int type,
            List<UnlockCondition> unlockConditions,
            List<NativeToken>? nativeTokens,
            List<Feature>? features,
            List<Feature>? immutableFeatures,
            string? stateMetadata)
            : base(amount, type, unlockConditions, nativeTokens, features, immutableFeatures)
        {
            StateMetadata = stateMetadata;
        }

        /// <summary>
        /// Metadata that can only be changed by the state controller.
        /// </summary>
        public string? StateMetadata { get; }
    }
}
