namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransaction
{
    internal class GetIncomingTransactionQueryModelData
    {
        public GetIncomingTransactionQueryModelData(string transactionId)
        {
            TransactionId = transactionId;
        }

        public string TransactionId { get; }
    }
}
