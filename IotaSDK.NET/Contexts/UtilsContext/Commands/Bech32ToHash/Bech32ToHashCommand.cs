using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash
{
    internal class Bech32ToHashCommand :RustBridgeRequest<string>
    {
        public Bech32ToHashCommand(string bech32Address, string rustMethodName) : base(rustMethodName)
        {
            Bech32Address = bech32Address;
        }

        public string Bech32Address { get; }
    }
}
