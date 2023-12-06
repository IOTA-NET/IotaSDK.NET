using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * An Expiration Unlock Condition.
     */
    public class ExpirationUnlockCondition : UnlockCondition
    {
        public ExpirationUnlockCondition(Address returnAddress, ulong unixTime) : base((int)UnlockConditionType.Expiration)
        {
            ReturnAddress = returnAddress;
            UnixTime = unixTime;
        }

        /**
         * The return address if the output was not claimed in time.
         * The address that can unlock the expired output.
         */

        public Address ReturnAddress { get; }

        /**
         * Before this timestamp, the condition is allowed to unlock the output,
         * after that only the address defined in return address is allowed to unlock the output.
         * The Unix timestamp marking the end of the claim period.
         */
        public ulong UnixTime { get; }
    }
}
