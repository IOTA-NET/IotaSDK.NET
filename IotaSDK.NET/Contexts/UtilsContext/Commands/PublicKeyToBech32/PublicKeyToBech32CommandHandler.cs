using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32
{
    internal class PublicKeyToBech32CommandHandler : IRequestHandler<PublicKeyToBech32Command, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public PublicKeyToBech32CommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(PublicKeyToBech32Command request, CancellationToken cancellationToken)
        {
            PublicKeyToBech32CommandModelData modelData = new PublicKeyToBech32CommandModelData(request.HexEncodedPublicKey, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
            IotaSDKModel<PublicKeyToBech32CommandModelData> model = new IotaSDKModel<PublicKeyToBech32CommandModelData>("hexPublicKeyToBech32Address", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
