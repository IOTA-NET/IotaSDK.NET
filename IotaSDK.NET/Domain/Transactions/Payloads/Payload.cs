using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(MilestonePayload), (int)PayloadType.Milestone)]
    [JsonSubtypes.KnownSubType(typeof(TaggedDataPayload), (int)PayloadType.TaggedData)]
    [JsonSubtypes.KnownSubType(typeof(TransactionPayload), (int)PayloadType.Transaction)]
    [JsonSubtypes.KnownSubType(typeof(TreasuryTransactionPayload), (int)PayloadType.TreasuryTransaction)]
    public abstract class Payload
    {
        public Payload(int type)
        {
            Type = type;
        }
        public int Type { get; private set; }

        public PayloadType GetPayloadType()
        {
            if (Enum.IsDefined(typeof(PayloadType), this.Type))
            {
                return (PayloadType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid PayloadType value");
            }
        }
    }
}
