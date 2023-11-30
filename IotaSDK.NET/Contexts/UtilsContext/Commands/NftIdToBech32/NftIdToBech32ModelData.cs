namespace IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32
{
    internal class NftIdToBech32ModelData
    {
        public NftIdToBech32ModelData(string nftId, string bech32Hrp)
        {
            NftId = nftId;
            Bech32Hrp = bech32Hrp;
        }

        public string NftId { get; }
        public string Bech32Hrp { get; }
    }
}
