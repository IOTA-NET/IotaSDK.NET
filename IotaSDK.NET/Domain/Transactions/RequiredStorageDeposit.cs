namespace IotaSDK.NET.Domain.Transactions
{
    public class RequiredStorageDeposit
    {
        public RequiredStorageDeposit(ulong alias, ulong basic, ulong foundry, ulong nft)
        {
            Alias = alias;
            Basic = basic;
            Foundry = foundry;
            Nft = nft;
        }

        public ulong Alias { get; set; }

        public ulong Basic { get; set; }

        public ulong Foundry { get; set; }

        public ulong Nft { get; set; }
    }
}
