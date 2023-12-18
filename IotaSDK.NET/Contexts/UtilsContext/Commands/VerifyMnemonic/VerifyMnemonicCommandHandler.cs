using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic
{
    internal class VerifyMnemonicCommandHandler : RustBridgeCommonHandler<VerifyMnemonicCommand, IotaSDKResponse<bool>, bool, VerifyMnemonicCommandModelData>
    {
        public VerifyMnemonicCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override VerifyMnemonicCommandModelData CreateModelData(VerifyMnemonicCommand request)
        {
            return new VerifyMnemonicCommandModelData(request.Mnemonic);
        }
    }
}
