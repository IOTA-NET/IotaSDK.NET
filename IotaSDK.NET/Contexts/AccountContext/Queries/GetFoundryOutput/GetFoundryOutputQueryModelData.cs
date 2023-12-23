namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetFoundryOutput
{
    internal class GetFoundryOutputQueryModelData
    {
        public GetFoundryOutputQueryModelData(string tokenId)
        {
            TokenId = tokenId;
        }

        public string TokenId { get; }
    }

}
