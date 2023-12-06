using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /**
     * An Immutable Alias Address Unlock Condition.
     */
    public class ImmutableAliasAddressUnlockCondition : UnlockCondition
    {
        public ImmutableAliasAddressUnlockCondition(int type, Address address) : base(type)
        {
            Address = address;
        }

        /// <summary>
        /// The Immutable Alias address that owns the output.
        /// </summary>
        public Address Address { get; }
    }
}
