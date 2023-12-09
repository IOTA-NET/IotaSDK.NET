using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions.EssenceTypes;
using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Inputs
{
    public enum InputType
    {
        /** A UTXO input. */
        UTXO = 0,
        /** The treasury input. */
        Treasury = 1,
    }

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
