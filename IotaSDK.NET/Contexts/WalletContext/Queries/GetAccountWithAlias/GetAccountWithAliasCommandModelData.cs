namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasCommandModelData
    {
        public GetAccountWithAliasCommandModelData(string alias)
        {
            AccountId = alias;
        }

        public string AccountId { get; }
    }
}
