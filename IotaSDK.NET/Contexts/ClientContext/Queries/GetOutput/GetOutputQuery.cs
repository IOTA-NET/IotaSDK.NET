using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetOutput
{
    internal class GetOutputQuery : ClientRequest<IotaSDKResponse<ClientOutputResponse>>
    {
        public GetOutputQuery(IntPtr clientHandle, string outputId) : base(clientHandle)
        {
            OutputId = outputId;
        }

        public string OutputId { get; }
    }
}
