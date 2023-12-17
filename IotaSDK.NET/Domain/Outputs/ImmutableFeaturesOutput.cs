using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public abstract class ImmutableFeaturesOutput : CommonOutput
    {
        protected ImmutableFeaturesOutput(string amount, int type, List<UnlockCondition> unlockConditions, List<NativeToken>? nativeTokens, List<Feature>? features, List<Feature>? immutableFeatures) 
            : base(amount, type, unlockConditions, nativeTokens, features)
        {
            ImmutableFeatures = immutableFeatures;
        }

        //public ImmutableFeaturesOutput(
        //    string amount,
        //    int type,
        //    List<UnlockCondition> unlockConditions, List<Feature>? immutableFeatures)
        //    : base(amount, type, unlockConditions, null, null)
        //{
        //    ImmutableFeatures = immutableFeatures;
        //}

        public List<Feature>? ImmutableFeatures { get; }
    }
}
