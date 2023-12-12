namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexQueryModelData
    {
        public GetAccountWithIndexQueryModelData(int index)
        {
            AccountId = index;
        }

        public int AccountId { get; set; }
    }
}
