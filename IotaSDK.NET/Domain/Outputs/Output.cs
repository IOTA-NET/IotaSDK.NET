using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Outputs
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(AliasOutput), (int)OutputType.Alias)]
    [JsonSubtypes.KnownSubType(typeof(BasicOutput), (int)OutputType.Basic)]
    [JsonSubtypes.KnownSubType(typeof(FoundryOutput), (int)OutputType.Foundry)]
    [JsonSubtypes.KnownSubType(typeof(NftOutput), (int)OutputType.Nft)]
    [JsonSubtypes.KnownSubType(typeof(TreasuryOutput), (int)OutputType.Treasury)]
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
