namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHex
{
    internal class Bech32ToHexCommandModelData
    {
        public Bech32ToHexCommandModelData(string bech32)
        {
            Bech32 = bech32;
        }

        public string Bech32 { get; }
    }
}
