using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Events
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(ConsolidationRequiredWalletEvent), (int)WalletEventType.ConsolidationRequired)]
    [JsonSubtypes.KnownSubType(typeof(LedgerAddressGenerationWalletEvent), (int)WalletEventType.LedgerAddressGeneration)]
    [JsonSubtypes.KnownSubType(typeof(NewOutputWalletEvent), (int)WalletEventType.NewOutput)]
    [JsonSubtypes.KnownSubType(typeof(SpentOutputWalletEvent), (int)WalletEventType.SpentOutput)]
    [JsonSubtypes.KnownSubType(typeof(TransactionInclusionWalletEvent), (int)WalletEventType.TransactionInclusion)]
    [JsonSubtypes.KnownSubType(typeof(TransactionProgressWalletEvent), (int)WalletEventType.TransactionProgress)]
    public abstract class WalletEvent
    {
        public int Type { get; }

        public WalletEvent(int type)
        {
            Type = type;
        }

        public WalletEventType GetWalletEventType()
        {
            if (Enum.IsDefined(typeof(WalletEventType), Type))
            {
                return (WalletEventType)Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(Type), "Invalid WalletEventType value");
            }
        }

    }
}
