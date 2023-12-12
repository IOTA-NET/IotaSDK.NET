namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexCommandModelData
    {
        public GetAccountWithIndexCommandModelData(int index)
        {
            AccountId = index;
        }

        public int AccountId { get; set; }
    }
}
