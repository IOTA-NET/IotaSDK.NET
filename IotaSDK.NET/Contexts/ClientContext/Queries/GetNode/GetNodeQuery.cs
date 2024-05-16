using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Network;
using System;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNode
{
    internal class GetNodeQuery : ClientRequest<IotaSDKResponse<Node>>
    {
        public GetNodeQuery(IntPtr clientHandle) : base(clientHandle)
        {
        }
    }
}
