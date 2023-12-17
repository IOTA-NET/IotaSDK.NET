using IotaSDK.NET.Domain.Features;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class BasicOutput : CommonOutput
    {
        public BasicOutput(string amount, List<UnlockCondition> unlockConditions, List<NativeToken>? nativeTokens, List<Feature>? features) 
            : base(amount, (int)OutputType.Basic, unlockConditions, nativeTokens, features)
        {
        }
    }
}
