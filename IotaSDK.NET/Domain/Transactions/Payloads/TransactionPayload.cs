using IotaSDK.NET.Domain.Transactions.EssenceTypes;
using IotaSDK.NET.Domain.Transactions.Unlocks;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    public class TransactionPayload : Payload
    {
        public TransactionPayload(TransactionEssence essence, List<Unlock> unlocks)
        {
            Essence = essence;
            Unlocks = unlocks;
        }
        public TransactionPayload()
        {
            Type = (int)PayloadType.Transaction;
        }
        /// <summary>
        /// The index namae
        /// </summary>
        public TransactionEssence Essence { get; set; }

        public List<Unlock> Unlocks { get; set; }
    }
}
