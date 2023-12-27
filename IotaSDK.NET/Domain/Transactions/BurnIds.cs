using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Transactions
{
    public class BurnIds
    {
        /** Aliases to burn */
        public List<string>? Aliases { get; set; }

        /** NFTs to burn */
        public List<string>? Nfts { get; set; }

        /** Foundries to burn */
        public List<string>? Foundries { get; set; }

        /** Amounts of native tokens to burn */
        public Dictionary<string, ulong>? NativeTokens { get; set; }
    }
}
