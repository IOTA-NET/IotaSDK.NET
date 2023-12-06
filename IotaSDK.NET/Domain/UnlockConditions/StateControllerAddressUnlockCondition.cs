using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /// <summary>
    /// A State Controller Address Unlock Condition.
    /// </summary>
    public class StateControllerAddressUnlockCondition : UnlockCondition
    {
        public StateControllerAddressUnlockCondition(Address address) : base((int)UnlockConditionType.StateControllerAddress)
        {
            Address = address;
        }

        /// <summary>
        /// The State Controller address that is allowed to do state transitions.
        /// </summary>
        public Address Address { get; }
    }
}
