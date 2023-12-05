using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic
{
    internal class GenerateMnemonicCommand : RustBridgeRequest<string>
    {
        public GenerateMnemonicCommand(string rustMethodName) : base(rustMethodName)
        {
        }
    }
}
