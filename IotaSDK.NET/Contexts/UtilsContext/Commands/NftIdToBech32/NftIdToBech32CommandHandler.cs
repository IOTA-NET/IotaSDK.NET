using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32
{
    internal class NftIdToBech32CommandHandler : RustBridgeCommonHandler<NftIdToBech32Command, IotaSDKResponse<string>, string, NftIdToBech32CommandModelData>
    {
        public NftIdToBech32CommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override NftIdToBech32CommandModelData CreateModelData(NftIdToBech32Command request)
        {
            string nftId = request.NftId;
            string humanReadablePart = HumanReadablePartEnumConverter.Convert(request.HumanReadablePart);

            return new NftIdToBech32CommandModelData(nftId, humanReadablePart);
        }
    }
}
