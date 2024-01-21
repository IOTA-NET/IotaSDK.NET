using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions.EssenceTypes;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    ///A 'prepared transaction' progress.
    /// </summary>
    public class PreparedTransactionProgress : TransactionProgress
    {
        public PreparedTransactionProgress(TransactionEssence essence, List<InputSigningData> inputData, Remainder? remainder) : base((int)TransactionProgressType.PreparedTransaction)
        {
            Essence = essence;
            InputData = inputData;
            Remainder = remainder;
        }

        /// <summary>
        /// The essence of the prepared transaction.
        /// </summary>
        public TransactionEssence Essence { get; }

        /// <summary>
        /// Input signing parameters.
        /// </summary>
        public List<InputSigningData> InputData { get; }

        /// <summary>
        /// Remainder output parameters.
        /// </summary>
        public Remainder? Remainder { get; }
    }
}
