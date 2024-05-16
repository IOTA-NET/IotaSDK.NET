using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetOutputs
{
    internal class GetOutputsQuery : ClientRequest<IotaSDKResponse<List<ClientOutputResponse>>>
    {
        public GetOutputsQuery(IntPtr clientHandle, List<string> outputIds) : base(clientHandle)
        {
            OutputIds = outputIds;
        }

        public List<string> OutputIds { get; }
    }
}
