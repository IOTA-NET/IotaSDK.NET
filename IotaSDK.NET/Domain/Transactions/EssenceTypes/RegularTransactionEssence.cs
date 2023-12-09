using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Outputs;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions.EssenceTypes
{
    public class RegularTransactionEssence : TransactionEssence
    {
        public RegularTransactionEssence(string networkId, string inputsCommitment, List<Input> inputs, List<Output> outputs) 
            : base((int)TransactionEssenceType.Regular)
        {
            NetworkId = networkId;
            InputsCommitment = inputsCommitment;
            Inputs = inputs;
            Outputs = outputs;
        }

        /// <summary>
        /// The ID of the network the transaction was issued to.
        /// </summary>
        public string NetworkId { get; }

        /// <summary>
        /// The hexencoded hash of all inputs.
        /// </summary>
        public string InputsCommitment { get; }

        /// <summary>
        /// The inputs of the transaction.
        /// </summary>
        public List<Input> Inputs { get; } = new List<Input>();

        /// <summary>
        /// The outputs of the transaction.
        /// </summary>
        public List<Output> Outputs { get; }
    }
}
