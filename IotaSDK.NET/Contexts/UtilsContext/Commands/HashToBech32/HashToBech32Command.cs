using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32
{
    internal class HashToBech32Command : RustBridgeRequest<string>
    {
        public HashToBech32Command(string hexEncodedHash, HumanReadablePart humanReadablePart, string rustMethodName) : base(rustMethodName)
        {
            HexEncodedHash = hexEncodedHash;
            HumanReadablePart = humanReadablePart;
        }

        public string HexEncodedHash { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
