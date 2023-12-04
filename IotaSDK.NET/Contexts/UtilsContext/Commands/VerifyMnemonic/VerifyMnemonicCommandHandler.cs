using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic
{
    internal class VerifyMnemonicCommandHandler : IRequestHandler<VerifyMnemonicCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public VerifyMnemonicCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<bool>> Handle(VerifyMnemonicCommand request, CancellationToken cancellationToken)
        {
            VerifyMnemonicCommandModelData modelData = new VerifyMnemonicCommandModelData(request.Mnemonic);
            IotaSDKModel<VerifyMnemonicCommandModelData> model = new IotaSDKModel<VerifyMnemonicCommandModelData>(name: "verifyMnemonic", modelData);

            string json = model.AsJson();

            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(callUtilsResponse, type: "verifyMnemonic");
            response.Payload = true;

            return response;
        }
    }
}
