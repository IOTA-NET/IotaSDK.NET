using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32
{
    internal class PublicKeyToBech32Command : IRequest<IotaSDKResponse<string>>
    {
        public PublicKeyToBech32Command(string hexEncodedPublicKey, HumanReadablePart humanReadablePart)
        {
            HexEncodedPublicKey = hexEncodedPublicKey;
            HumanReadablePart = humanReadablePart;
        }

        public string HexEncodedPublicKey { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
