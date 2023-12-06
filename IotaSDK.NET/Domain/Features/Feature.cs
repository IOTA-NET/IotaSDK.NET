using IotaSDK.NET.Domain.Addresses;
using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Features
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AliasAddress), (int)FeatureType.Sender)]
    [JsonSubtypes.KnownSubType(typeof(Ed25519Address), (int)FeatureType.Issuer)]
    [JsonSubtypes.KnownSubType(typeof(NftAddress), (int)FeatureType.Metadata)]
    [JsonSubtypes.KnownSubType(typeof(NftAddress), (int)FeatureType.Tag)]
    public abstract class Feature
    {
        public Feature(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public FeatureType GetFeatureType()
        {
            if (Enum.IsDefined(typeof(FeatureType), this.Type))
            {
                return (FeatureType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid FeatureType value");
            }
        }
    }
}
