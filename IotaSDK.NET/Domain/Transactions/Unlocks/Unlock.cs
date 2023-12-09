using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(ReferenceUnlock), (int)UnlockType.Reference)]
    [JsonSubtypes.KnownSubType(typeof(SignatureUnlock), (int)UnlockType.Signature)]
    [JsonSubtypes.KnownSubType(typeof(NftUnlock), (int)UnlockType.Nft)]
    [JsonSubtypes.KnownSubType(typeof(AliasUnlock), (int)UnlockType.Alias)]
    public abstract class Unlock
    {
        public Unlock(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public UnlockType GetUnlockType()
        {
            if (Enum.IsDefined(typeof(UnlockType), this.Type))
            {
                return (UnlockType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid UnlockType value");
            }
        }
    }
}
