using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class BasicOutput : CommonOutput
    {
        public BasicOutput(
            string amount, 
            int type, 
            List<UnlockCondition> unlockConditions) 
            : base(amount, type, unlockConditions, null, null)
        {
        }
    }
}
