using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft
{
    internal class PrepareBurnNftCommandModelDataBurn
    {
        public PrepareBurnNftCommandModelDataBurn(List<string> nfts)
        {
            Nfts = nfts;
        }

        public List<string> Nfts { get; }
    }
}
