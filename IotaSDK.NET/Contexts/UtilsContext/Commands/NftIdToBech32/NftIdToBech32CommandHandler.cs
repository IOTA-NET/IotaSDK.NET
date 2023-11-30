using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32
{
    internal class NftIdToBech32CommandHandler : IRequestHandler<NftIdToBech32Command, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public NftIdToBech32CommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async  Task<IotaSDKResponse<string>> Handle(NftIdToBech32Command request, CancellationToken cancellationToken)
        {
            string nftId = request.NftId;
            string humanReadablePart = HumanReadablePartEnumConverter.Convert(request.HumanReadablePart);

            NftIdToBech32CommandModelData modelData = new NftIdToBech32CommandModelData(nftId, humanReadablePart);
            IotaSDKModel<NftIdToBech32CommandModelData> model = new IotaSDKModel<NftIdToBech32CommandModelData>(name: "nftIdToBech32", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
