using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * An address unlock condition.
     * An address unlocked with a private key.
     */
    public class AddressUnlockCondition : UnlockCondition
    {
        public AddressUnlockCondition(int type, Address address) : base(type)
        {
            Address = address;
        }

        /**
         * @param address The address that needs to be unlocked with a private key.
         */
        public Address Address { get; }
    }
}
