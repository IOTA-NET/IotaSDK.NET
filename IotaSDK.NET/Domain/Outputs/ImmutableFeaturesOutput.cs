using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public abstract class ImmutableFeaturesOutput : CommonOutput
    {
        public ImmutableFeaturesOutput(
            string amount, 
            int type, 
            List<UnlockCondition> unlockConditions, List<Feature>? immutableFeatures) 
            : base(amount, type, unlockConditions, null, null)
        {
            ImmutableFeatures = immutableFeatures;
        }

        public List<Feature>? ImmutableFeatures { get; }
    }
}
