using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic
{
    internal class GenerateMnemonicCommandHandler : IRequestHandler<GenerateMnemonicCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public GenerateMnemonicCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(GenerateMnemonicCommand request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel(name: "generateMnemonic");
            string json = model.AsJson();
            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);


            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
