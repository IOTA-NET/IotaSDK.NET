namespace IotaSDK.NET.Domain.Events
{
    public class TransactionInclusionWalletEvent : WalletEvent
    {

        public TransactionInclusionWalletEvent(string transactionId, string inclusionState)
            : base((int)WalletEventType.TransactionInclusion)
        {
            TransactionId = transactionId;
            InclusionState = inclusionState;
        }

        /// <summary>
        /// The transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// The inclusion state of the transaction.
        /// </summary>
        public string InclusionState { get; set; }
    }

}
