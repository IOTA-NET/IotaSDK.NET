using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Addresses
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AliasAddress), (int)AddressType.Alias)]
    [JsonSubtypes.KnownSubType(typeof(Ed25519Address), (int)AddressType.Ed25519)]
    [JsonSubtypes.KnownSubType(typeof(NftAddress), (int)AddressType.Nft)]
    public abstract class Address
    {
        public Address(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public AddressType GetAddressType()
        {
            if (Enum.IsDefined(typeof(AddressType), this.Type))
            {
                return (AddressType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid AddressType value");
            }
        }
    }
}
