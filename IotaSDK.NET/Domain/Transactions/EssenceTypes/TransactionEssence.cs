using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace IotaSDK.NET.Domain.Transactions.EssenceTypes
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(RegularTransactionEssence), (int)TransactionEssenceType.Regular)]
    public abstract class TransactionEssence
    {
        public TransactionEssence(int type)
        {
            Type = type;
        }

        public int Type { get; }

        public TransactionEssenceType GetTransactionEssenceType()
        {
            if (Enum.IsDefined(typeof(TransactionEssenceType), this.Type))
            {
                return (TransactionEssenceType)this.Type;
            }
            else
            {
                // Handle the case where the input value doesn't match any enum value
                throw new ArgumentOutOfRangeException(nameof(this.Type), "Invalid TransactionEssenceType value");
            }
        }
    }
}
