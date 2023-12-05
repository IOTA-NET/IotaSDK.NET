using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed
{
    internal class MnemonicToHexSeedCommandHandler : RustBridgeCommonHandler<MnemonicToHexSeedCommand, IotaSDKResponse<string>, string, MnemonicToHexSeedCommandModelData>
    {
        public MnemonicToHexSeedCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override MnemonicToHexSeedCommandModelData CreateModelData(MnemonicToHexSeedCommand request)
        {
            return new MnemonicToHexSeedCommandModelData(request.Mnemonic);
        }
    }
}
