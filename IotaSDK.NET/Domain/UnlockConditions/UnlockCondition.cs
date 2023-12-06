using System;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    public abstract class UnlockCondition
    {
        public UnlockCondition(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public UnlockConditionType GetUnlockConditionType()
        {
            if (Enum.IsDefined(typeof(UnlockConditionType), this.Type))
            {
                return (UnlockConditionType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid UnlockConditionType value");
            }
        }
    }
}
