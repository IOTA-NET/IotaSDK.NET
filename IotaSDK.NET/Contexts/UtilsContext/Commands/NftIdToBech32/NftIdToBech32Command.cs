using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32
{
    internal class NftIdToBech32Command : IRequest<IotaSDKResponse<string>>
    {
        public NftIdToBech32Command(string nftId, HumanReadablePart humanReadablePart)
        {
            NftId = nftId;
            HumanReadablePart = humanReadablePart;
        }

        public string NftId { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
