using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * A Storage Deposit Return Unlock Condition.
     */
    public class StorageDepositReturnUnlockCondition : UnlockCondition
    {
        public StorageDepositReturnUnlockCondition(string amount, Address returnAddress) : base((int)UnlockConditionType.StorageDepositReturn)
        {
            Amount = amount;
            ReturnAddress = returnAddress;
        }

        /**
         * The amount the consuming transaction must deposit to `returnAddress`.
         */
        public string Amount { get; }

        /**
         * The address to return the amount to.
         */
        public Address ReturnAddress { get; }
    }
}
