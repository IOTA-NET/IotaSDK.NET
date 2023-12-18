using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.ComputeStorageDeposit
{
    internal class ComputeStorageDepositCommandHandler : RustBridgeCommonHandler<ComputeStorageDepositCommand, IotaSDKResponse<string>, string, ComputeStorageDepositCommandModelData>
    {
        public ComputeStorageDepositCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override ComputeStorageDepositCommandModelData CreateModelData(ComputeStorageDepositCommand request)
        {
            return new ComputeStorageDepositCommandModelData(request.Output, request.Rent);
        }
    }
}
