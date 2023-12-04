namespace IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32
{
    internal class PublicKeyToBech32CommandModelData
    {
        public PublicKeyToBech32CommandModelData(string hex, string bech32Hrp)
        {
            Hex = hex;
            Bech32Hrp = bech32Hrp;
        }

        public string Hex { get; }
        public string Bech32Hrp { get; }
    }
}
