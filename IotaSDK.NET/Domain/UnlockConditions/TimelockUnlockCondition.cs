namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * A Timelock Unlock Condition.
     */
    public class TimelockUnlockCondition : UnlockCondition
    {
        public TimelockUnlockCondition(ulong unixTime) : base((int)UnlockConditionType.Timelock)
        {
            UnixTime = unixTime;
        }

        /**
         * The Unix time (seconds since Unix epoch) starting from which the output can be consumed.
         */
        public ulong UnixTime { get; }
    }
}
