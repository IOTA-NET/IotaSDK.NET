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
            string? stateMetadata)
            : base(amount, type, unlockConditions, null)
        {
            StateMetadata = stateMetadata;
        }

        /// <summary>
        /// Metadata that can only be changed by the state controller.
        /// </summary>
        public string? StateMetadata { get; }
    }
}
