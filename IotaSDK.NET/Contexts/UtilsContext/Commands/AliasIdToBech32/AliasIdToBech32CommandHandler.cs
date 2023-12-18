using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.AliasIdToBech32
{

    internal class AliasIdToBech32CommandHandler
        : RustBridgeCommonHandler<AliasIdToBech32Command, IotaSDKResponse<string>, string, AliasIdToBech32CommandModelData>
    {
        public AliasIdToBech32CommandHandler(RustBridgeCommon rustBridgeCommon)
            : base(rustBridgeCommon)
        {
        }

        public override AliasIdToBech32CommandModelData CreateModelData(AliasIdToBech32Command request)
        {
            return new AliasIdToBech32CommandModelData(request.AliasId, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
        }
    }
}
