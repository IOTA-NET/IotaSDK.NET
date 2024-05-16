using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNodeHealthStatus
{
    internal class GetNodeHealthStatusQuery : ClientRequest<IotaSDKResponse<bool>>
    {
        public GetNodeHealthStatusQuery(IntPtr clientHandle, string url) : base(clientHandle)
        {
            Url = url;
        }

        public string Url { get; }
    }
}
