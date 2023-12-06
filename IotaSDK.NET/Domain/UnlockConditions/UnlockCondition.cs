using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.UnlockConditions
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AddressUnlockCondition), (int)UnlockConditionType.Address)]
    [JsonSubtypes.KnownSubType(typeof(StorageDepositReturnUnlockCondition), (int)UnlockConditionType.StorageDepositReturn)]
    [JsonSubtypes.KnownSubType(typeof(TimelockUnlockCondition), (int)UnlockConditionType.Timelock)]
    [JsonSubtypes.KnownSubType(typeof(ExpirationUnlockCondition), (int)UnlockConditionType.Expiration)]
    [JsonSubtypes.KnownSubType(typeof(StateControllerAddressUnlockCondition), (int)UnlockConditionType.StateControllerAddress)]
    [JsonSubtypes.KnownSubType(typeof(GovernorAddressUnlockCondition), (int)UnlockConditionType.GovernorAddress)]
    [JsonSubtypes.KnownSubType(typeof(ImmutableAliasAddressUnlockCondition), (int)UnlockConditionType.ImmutableAliasAddress)]
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
