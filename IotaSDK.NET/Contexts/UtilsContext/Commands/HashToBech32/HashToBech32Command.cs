using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32
{
    internal class HashToBech32Command : IRequest<IotaSDKResponse<string>>
    {
        public HashToBech32Command(string hexEncodedHash, HumanReadablePart humanReadablePart)
        {
            HexEncodedHash = hexEncodedHash;
            HumanReadablePart = humanReadablePart;
        }

        public string HexEncodedHash { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
