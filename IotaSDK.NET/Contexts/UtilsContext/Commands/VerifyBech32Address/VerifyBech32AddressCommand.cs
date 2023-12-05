using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address
{
    internal class VerifyBech32AddressCommand : RustBridgeRequest<bool>
    {
        public VerifyBech32AddressCommand(string bech32Address, string rustMethodName) : base(rustMethodName)
        {
            Bech32Address = bech32Address;
        }
        public string Bech32Address { get; }
    }
}
