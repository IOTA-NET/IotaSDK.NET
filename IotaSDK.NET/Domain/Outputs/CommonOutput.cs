using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public abstract class CommonOutput : Output
    {
        protected CommonOutput(string amount,
            int type,
            List<UnlockCondition> unlockConditions,
            List<NativeToken>? nativeTokens,
            List<Feature>? features)
            : base(amount, type)
        {
            UnlockConditions = unlockConditions;
            NativeTokens = nativeTokens;
            Features = features;
        }

        public List<UnlockCondition> UnlockConditions { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<NativeToken>? NativeTokens { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Feature>? Features { get; }
    }
}
