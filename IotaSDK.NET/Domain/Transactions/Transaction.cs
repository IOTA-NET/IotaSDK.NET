using IotaSDK.NET.Domain.Transactions.Payloads;

namespace IotaSDK.NET.Domain.Transactions
{
    public class Transaction
    {
        public Transaction(TransactionPayload payload, string blockId, string timestamp, string transactionId, string networkId, bool incoming, string inclusionState)
        {
            Payload = payload;
            BlockId = blockId;
            Timestamp = timestamp;
            TransactionId = transactionId;
            NetworkId = networkId;
            Incoming = incoming;
            InclusionState = inclusionState;
        }

        /// <summary>
        /// The transaction payload
        /// </summary>
        public TransactionPayload Payload { get; set; }

        /// <summary>
        /// The block id in which the transaction payload was included
        /// </summary>
        public string BlockId { get; set; }

        public string InclusionState { get; set; }

        /// <summary>
        /// The creation time
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The transaction id
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// The network id in which the transaction was sent
        /// </summary>
        public string NetworkId { get; set; }

        /// <summary>
        /// If the transaction was created by the wallet or someone else
        /// </summary>
        public bool Incoming { get; set; }

        /// <summary>
        ///  Note that can be set when sending a transaction and is only stored locally
        /// </summary>
        public string? Note { get; set; }
    }
}
