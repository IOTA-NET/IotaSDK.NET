using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic
{
    internal class VerifyMnemonicCommand : RustBridgeRequest<bool>
    {
        public VerifyMnemonicCommand(string mnemonic, string rustMethodName) : base(rustMethodName)
        {
            Mnemonic = mnemonic;
        }
        public string Mnemonic { get; }
    }
}
