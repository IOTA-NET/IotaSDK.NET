namespace IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic
{
    internal class StoreMnemonicCommandModelData
    {
        public StoreMnemonicCommandModelData(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
