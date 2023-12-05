using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace IotaSDK.NET.Domain.Outputs
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    //[JsonSubtypes.KnownSubType(typeof(AliasOutput), 4)]
    //[JsonSubtypes.KnownSubType(typeof(BasicOutput), 3)]
    //[JsonSubtypes.KnownSubType(typeof(FoundryOutput), 5)]
    //[JsonSubtypes.KnownSubType(typeof(NftOutput), 6)]
    //[JsonSubtypes.KnownSubType(typeof(TreasuryOutput), 2)]
    public abstract class Output
    {
        public Output(string amount, int type)
        {
            Amount = amount;
            Type = type;
        }

        public string Amount { get; }
        public int Type { get; }

        public OutputType GetOutputType()
        {
            if (Enum.IsDefined(typeof(OutputType), this.Type))
            {
                return (OutputType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid OutputType value");
            }
        }
        
        public ulong GetAmount()
        {
            if(ulong.TryParse(this.Amount, out var value))
            {
                return value;
            }
            throw new ArgumentOutOfRangeException(nameof(this.Amount), $"Invalid Amount of {Amount}");

        }
    }
}
