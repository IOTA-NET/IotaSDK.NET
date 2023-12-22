namespace IotaSDK.NET.Domain.Transactions.Prepared
{
    public class PreparedNativeTokenTransactionData
    {
        public PreparedNativeTokenTransactionData(string tokenId, PreparedTransactionData transaction)
        {
            TokenId = tokenId;
            Transaction = transaction;
        }

        public string TokenId { get; }
        public PreparedTransactionData Transaction { get; }
    }
}
