using IotaSDK.NET.Domain.Inputs;
using IotaSDK.NET.Domain.Transactions.Payloads;

namespace IotaSDK.NET.Domain.Signatures
{
    /// <summary>
    /// The signed transaction with inputs data
    /// </summary>
    public class SignedTransactionEssence
    {
        public SignedTransactionEssence(InputSigningData inputsData, TransactionPayload transactionPayload)
        {
            InputsData = inputsData;
            TransactionPayload = transactionPayload;
        }

        /// <summary>
        /// Signed inputs data
        /// </summary>
        public InputSigningData InputsData { get; }

        /// <summary>
        /// A transaction payload.
        /// </summary>
        public TransactionPayload TransactionPayload { get; }
    }
}
