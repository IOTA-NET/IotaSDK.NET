using IotaSDK.NET.Domain.Transactions.EssenceTypes;
using IotaSDK.NET.Domain.Transactions.Unlocks;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    public class TransactionPayload : Payload
    {
        public TransactionPayload(TransactionEssence essence, List<Unlock> unlocks)
            : base((int)PayloadType.Transaction)
        {
            Essence = essence;
            Unlocks = unlocks;
        }
        /// <summary>
        /// The index namae
        /// </summary>
        public TransactionEssence Essence { get; set; }

        public List<Unlock> Unlocks { get; set; }
    }
}
