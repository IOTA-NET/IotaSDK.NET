namespace IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32
{
    internal class HashToBech32CommandModelData
    {
        public HashToBech32CommandModelData(string hex, string bech32Hrp)
        {
            Hex = hex;
            Bech32Hrp = bech32Hrp;
        }

        public string Hex { get; }
        public string Bech32Hrp { get; }
    }
}
