using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32
{
    internal class PublicKeyToBech32Command : RustBridgeRequest<string>
    {
        public PublicKeyToBech32Command(string hexEncodedPublicKey, HumanReadablePart humanReadablePart, string rustMethodName) : base(rustMethodName)
        {
            HexEncodedPublicKey = hexEncodedPublicKey;
            HumanReadablePart = humanReadablePart;
        }

        public string HexEncodedPublicKey { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
