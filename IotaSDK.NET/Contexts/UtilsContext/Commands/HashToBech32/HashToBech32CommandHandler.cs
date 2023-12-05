using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.HashToBech32
{
    internal class HashToBech32CommandHandler : RustBridgeCommonHandler<HashToBech32Command, IotaSDKResponse<string>, string, HashToBech32CommandModelData>
    {
        public HashToBech32CommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override HashToBech32CommandModelData CreateModelData(HashToBech32Command request)
        {
           return new HashToBech32CommandModelData(request.HexEncodedHash, HumanReadablePartEnumConverter.Convert(request.HumanReadablePart));
        }
    }
    
}
