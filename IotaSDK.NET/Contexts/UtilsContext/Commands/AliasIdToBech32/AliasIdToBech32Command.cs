using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Network;
using MediatR;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32
{
    internal class AliasIdToBech32Command : IRequest<IotaSDKResponse<string>>
    {
        public AliasIdToBech32Command(string aliasId, HumanReadablePart humanReadablePart)
        {
            AliasId = aliasId;
            HumanReadablePart = humanReadablePart;
        }

        public string AliasId { get; }
        public HumanReadablePart HumanReadablePart { get; }
    }
}
