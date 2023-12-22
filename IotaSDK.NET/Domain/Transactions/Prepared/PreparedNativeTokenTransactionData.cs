namespace IotaSDK.NET.Domain.Transactions.Prepared
{
    public class PreparedNativeTokenTransactionData
    {
        public PreparedNativeTokenTransactionData(string tokenId, PreparedTransactionData preparedTransactionData)
        {
            TokenId = tokenId;
            PreparedTransactionData = preparedTransactionData;
        }

        public string TokenId { get; }
        public PreparedTransactionData PreparedTransactionData { get; }
    }
}
