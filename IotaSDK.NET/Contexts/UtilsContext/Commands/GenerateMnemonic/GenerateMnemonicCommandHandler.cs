using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic
{
    internal class GenerateMnemonicCommandHandler : RustBridgeCommonHandler<GenerateMnemonicCommand, IotaSDKResponse<string>, string>
    {
        public GenerateMnemonicCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }
    }

}
