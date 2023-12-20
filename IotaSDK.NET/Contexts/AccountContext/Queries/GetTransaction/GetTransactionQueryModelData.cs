namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetTransaction
{
    internal class GetTransactionQueryModelData
    {
        public GetTransactionQueryModelData(string transactionId)
        {
            TransactionId = transactionId;
        }

        public string TransactionId { get; }
    }
}
