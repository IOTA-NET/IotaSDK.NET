using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyBech32Address
{
    internal class VerifyBech32AddressCommandHandler : RustBridgeCommonHandler<VerifyBech32AddressCommand, IotaSDKResponse<bool>, bool, VerifyBech32AddressCommandModelData>
    {
        public VerifyBech32AddressCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override VerifyBech32AddressCommandModelData CreateModelData(VerifyBech32AddressCommand request)
        {
            return new VerifyBech32AddressCommandModelData(request.Bech32Address);
        }
    }
}
