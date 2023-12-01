using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address
{
    internal class VerifyBech32AddressCommandHandler : IRequestHandler<VerifyBech32AddressCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public VerifyBech32AddressCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<bool>> Handle(VerifyBech32AddressCommand request, CancellationToken cancellationToken)
        {
            VerifyBech32AddressCommandModelData modelData = new VerifyBech32AddressCommandModelData(request.Bech32Address);
            IotaSDKModel<VerifyBech32AddressCommandModelData> model = new IotaSDKModel<VerifyBech32AddressCommandModelData>("isAddressValid", modelData);
            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<bool>.CreateInstance(callUtilsResponse);
        }
    }
}
