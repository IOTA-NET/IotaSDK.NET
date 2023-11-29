namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic
{
    internal class VerifyMnemonicCommandModelData
    {
        public VerifyMnemonicCommandModelData(string mnemonic)
        {
            Mnemonic = mnemonic;
        }

        public string Mnemonic { get; }
    }
}
