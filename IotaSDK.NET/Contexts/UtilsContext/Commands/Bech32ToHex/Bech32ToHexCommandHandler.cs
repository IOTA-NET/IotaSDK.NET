using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHex
{
    internal class Bech32ToHexCommandHandler : IRequestHandler<Bech32ToHexCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public Bech32ToHexCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(Bech32ToHexCommand request, CancellationToken cancellationToken)
        {
            Bech32ToHexCommandModelData modelData = new Bech32ToHexCommandModelData(request.Bech32Address);
            IotaSDKModel<Bech32ToHexCommandModelData> model = new IotaSDKModel<Bech32ToHexCommandModelData>("bech32ToHex", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);
            
            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
