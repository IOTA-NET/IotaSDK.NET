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

            NftIdToBech32ModelData modelData = new NftIdToBech32ModelData(nftId, humanReadablePart);
            IotaSDKModel<NftIdToBech32ModelData> model = new IotaSDKModel<NftIdToBech32ModelData>(name: "nftIdToBech32", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
