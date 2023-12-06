using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AddressUnlockCondition), 0)]
    [JsonSubtypes.KnownSubType(typeof(StorageDepositReturnUnlockCondition), 1)]
    [JsonSubtypes.KnownSubType(typeof(TimelockUnlockCondition), 2)]
    [JsonSubtypes.KnownSubType(typeof(ExpirationUnlockCondition), 3)]
    [JsonSubtypes.KnownSubType(typeof(StateControllerAddressUnlockCondition), 4)]
    [JsonSubtypes.KnownSubType(typeof(GovernorAddressUnlockCondition), 5)]
    [JsonSubtypes.KnownSubType(typeof(ImmutableAliasAddressUnlockCondition), 6)]
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
