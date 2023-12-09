using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Signatures
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(Ed25519Signature), (int)SignatureType.Ed25519)]
    public abstract class Signature
    {
        public Signature(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public SignatureType GetSignatureType()
        {
            if (Enum.IsDefined(typeof(SignatureType), this.Type))
            {
                return (SignatureType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid SignatureType value");
            }
        }
    }
}
