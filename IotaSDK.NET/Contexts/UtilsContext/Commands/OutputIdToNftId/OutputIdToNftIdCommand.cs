using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Contexts.UtilsContext.Commands.OutputIdToNftId
{
    internal class OutputIdToNftIdCommand : RustBridgeRequest<string>
    {
        public OutputIdToNftIdCommand(string outputId, string rustMethodName) : base(rustMethodName)
        {
            OutputId = outputId;
        }

        public string OutputId { get; }
    }
}
