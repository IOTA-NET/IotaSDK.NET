namespace IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed
{
    internal class MnemonicToHexSeedCommandModelData
    {
        public MnemonicToHexSeedCommandModelData(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
