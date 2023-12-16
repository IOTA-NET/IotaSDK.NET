using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions.EssenceTypes;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions.Prepared
{
    public class PreparedTransactionData
    {
        // Transaction essence
        public TransactionEssence Essence { get; set; }

        // Required address information for signing
        public List<InputSigningData> InputsData { get; set; }

        // Optional remainder output information
        public Remainder? Remainder { get; set; }

        // Constructor with default values
        public PreparedTransactionData(TransactionEssence essence, List<InputSigningData> inputsData, Remainder? remainder = null)
        {
            Essence = essence;
            InputsData = inputsData;
            Remainder = remainder;
        }
    }


}
