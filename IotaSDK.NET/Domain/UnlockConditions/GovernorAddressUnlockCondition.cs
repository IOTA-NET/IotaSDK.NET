﻿using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    /// <summary>
    /// A Governor Address Unlock Condition.
    /// </summary>
    public class GovernorAddressUnlockCondition : UnlockCondition
    {
        public GovernorAddressUnlockCondition(Address address) : base((int)UnlockConditionType.GovernorAddress)
        {
            Address = address;
        }

        /// <summary>
        /// The governor address that is allowed to do governance transitions.
        /// </summary>
        public Address Address { get; }
    }
}
