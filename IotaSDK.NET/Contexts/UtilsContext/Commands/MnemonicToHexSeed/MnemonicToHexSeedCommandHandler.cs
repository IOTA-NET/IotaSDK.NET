using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed
{
    internal class MnemonicToHexSeedCommandHandler : IRequestHandler<MnemonicToHexSeedCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeCommon _rustBridgeCommon;

        public MnemonicToHexSeedCommandHandler(RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<string>> Handle(MnemonicToHexSeedCommand request, CancellationToken cancellationToken)
        {
            MnemonicToHexSeedCommandModelData modelData = new MnemonicToHexSeedCommandModelData(request.Mnemonic);

            IotaSDKModel<MnemonicToHexSeedCommandModelData> model = new IotaSDKModel<MnemonicToHexSeedCommandModelData>("mnemonicToHexSeed", modelData);

            string json = model.AsJson();
            string? callUtilsResponse = await _rustBridgeCommon.CallUtilsMethodAsync(json);

            IotaSDKException.CheckForException(callUtilsResponse!);

            return IotaSDKResponse<string>.CreateInstance(callUtilsResponse);
        }
    }
}
