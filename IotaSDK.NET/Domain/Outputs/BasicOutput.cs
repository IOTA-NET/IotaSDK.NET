using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class BasicOutput : CommonOutput
    {
        public BasicOutput(
            string amount, 
            List<UnlockCondition> unlockConditions) 
            : base(amount, (int)OutputType.Basic, unlockConditions, null, null)
        {
        }
    }
}
