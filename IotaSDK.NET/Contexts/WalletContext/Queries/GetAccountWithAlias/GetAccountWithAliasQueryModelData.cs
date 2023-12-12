namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasQueryModelData
    {
        public GetAccountWithAliasQueryModelData(string alias)
        {
            AccountId = alias;
        }

        public string AccountId { get; }
    }
}
