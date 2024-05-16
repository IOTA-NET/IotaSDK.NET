using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNode
{
    internal class GetNodeQueryHandler : IRequestHandler<GetNodeQuery, IotaSDKResponse<Node>>
    {
        private readonly RustBridgeClient _rustBridgeClient;

        public GetNodeQueryHandler(RustBridgeClient rustBridgeClient)
        {
            _rustBridgeClient = rustBridgeClient;
        }

        public async Task<IotaSDKResponse<Node>> Handle(GetNodeQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("getNode");
            var json = model.AsJson();

            string? clientResponse = await _rustBridgeClient.CallClientMethodAsync(request.ClientHandle, json);

            IotaSDKException.CheckForException(clientResponse!);

            return IotaSDKResponse<Node>.CreateInstance(clientResponse);
        }
    }
}
