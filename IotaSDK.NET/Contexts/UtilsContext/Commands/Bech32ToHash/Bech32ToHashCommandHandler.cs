using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHash
{
    internal class Bech32ToHashCommandHandler : RustBridgeCommonHandler<Bech32ToHashCommand, IotaSDKResponse<string>, string, Bech32ToHashCommandModelData>
    {
        public Bech32ToHashCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override Bech32ToHashCommandModelData CreateModelData(Bech32ToHashCommand request)
        {
            return new Bech32ToHashCommandModelData(request.Bech32Address);

        }
    }
}
