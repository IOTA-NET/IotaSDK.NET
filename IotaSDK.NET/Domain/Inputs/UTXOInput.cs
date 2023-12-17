namespace IotaSDK.NET.Domain.Inputs
{
    /// <summary>
    ///  A UTXO transaction input.
    /// </summary>
    public class UTXOInput : Input
    {
        public UTXOInput(string transactionId, int transactionOutputIndex) : base((int)InputType.UTXO)
        {
            TransactionId = transactionId;
            TransactionOutputIndex = transactionOutputIndex;
        }

        /// <summary>
        /// The ID of the transaction it is an input of.
        /// </summary>
        public string TransactionId { get; }

        /// <summary>
        /// The index of the input within the transaction.
        /// </summary>
        public int TransactionOutputIndex { get; }
    }
}
