using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash
{
    internal class Bech32ToHashCommandHandler : IRequestHandler<Bech32ToHashCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public Bech32ToHashCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(Bech32ToHashCommand request, CancellationToken cancellationToken)
        {
            Bech32ToHashCommandModelData modelData = new Bech32ToHashCommandModelData(request.Bech32Address);
            IotaSDKModel<Bech32ToHashCommandModelData> model = new IotaSDKModel<Bech32ToHashCommandModelData>("bech32ToHex", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
