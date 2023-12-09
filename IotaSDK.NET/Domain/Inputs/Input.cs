using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Inputs
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(TreasuryInput), (int)InputType.Treasury)]
    [JsonSubtypes.KnownSubType(typeof(UTXOInput), (int)InputType.UTXO)]
    public abstract class Input
    {
        public Input(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public InputType GetInputType()
        {
            if (Enum.IsDefined(typeof(InputType), this.Type))
            {
                return (InputType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid InputType value");
            }
        }
    }
    }
