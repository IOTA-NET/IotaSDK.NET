using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions.Payloads;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Events
{
    public class NewOutputWalletEvent : WalletEvent
    {
        public NewOutputWalletEvent(OutputData output, TransactionPayload? transaction = null, List<TransactionInput>? transactionInputs = null) : base((int)WalletEventType.NewOutput)
        {
            Output = output;
            Transaction = transaction;
            TransactionInputs = transactionInputs;
        }

        /// <summary>
        /// The new output.
        /// </summary>
        public OutputData Output { get; }

        /// <summary>
        /// The transaction that created the output. Might be pruned and not available.
        /// </summary>
        public TransactionPayload? Transaction { get; }

        /// <summary>
        /// he inputs for the transaction that created the output. Might be pruned and not available.
        /// </summary>
        public List<TransactionInput>? TransactionInputs { get; }



    }

}
