using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.PublicKeyToBech32
{
    internal class PublicKeyToBech32CommandHandler : RustBridgeCommonHandler<PublicKeyToBech32Command, IotaSDKResponse<string>, string, PublicKeyToBech32CommandModelData>
    {
        public PublicKeyToBech32CommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override PublicKeyToBech32CommandModelData CreateModelData(PublicKeyToBech32Command request)
        {
            return new PublicKeyToBech32CommandModelData(request.HexEncodedPublicKey, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
        }
    }
}
