using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetOutputs
{
    internal class GetOutputsQueryModelData
    {
        public GetOutputsQueryModelData(List<string> outputIds)
        {
            OutputIds = outputIds;
        }

        public List<string> OutputIds { get; }
    }
}
