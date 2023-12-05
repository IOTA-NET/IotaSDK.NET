using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.OutputIdToNftId
{
    internal class OutputIdToNftIdCommandHandler : RustBridgeCommonHandler<OutputIdToNftIdCommand, IotaSDKResponse<string>, string, OutputIdToNftIdCommandModelData>
    {
        public OutputIdToNftIdCommandHandler(RustBridgeCommon rustBridgeCommon) : base(rustBridgeCommon)
        {
        }

        public override OutputIdToNftIdCommandModelData CreateModelData(OutputIdToNftIdCommand request)
        {
            return new OutputIdToNftIdCommandModelData(request.OutputId);
        }
    }
}
