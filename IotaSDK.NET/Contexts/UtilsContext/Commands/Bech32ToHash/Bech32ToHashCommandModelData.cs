namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash
{
    internal class Bech32ToHashCommandModelData
    {
        public Bech32ToHashCommandModelData(string bech32)
        {
            Bech32 = bech32;
        }

        public string Bech32 { get; }
    }
}
