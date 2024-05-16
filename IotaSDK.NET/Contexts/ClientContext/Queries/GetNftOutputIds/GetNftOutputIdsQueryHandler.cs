using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNftOutputIds
{
    internal class GetNftOutputIdsQueryHandler : IRequestHandler<GetNftOutputIdsQuery, IotaSDKResponse<ClientOutputsResponse>>
    {
        private readonly RustBridgeClient _rustBridgeClient;

        public GetNftOutputIdsQueryHandler(RustBridgeClient rustBridgeClient)
        {
            _rustBridgeClient = rustBridgeClient;
        }
        public async Task<IotaSDKResponse<ClientOutputsResponse>> Handle(GetNftOutputIdsQuery request, CancellationToken cancellationToken)
        {
            var modelData = new GetNftOutputIdsQueryModelData(request.QueryParameters);
            var model = new IotaSDKModel<GetNftOutputIdsQueryModelData>("nftOutputIds", modelData);
            var json = model.AsJson();

            string? clientResponse = await _rustBridgeClient.CallClientMethodAsync(request.ClientHandle, json);

            IotaSDKException.CheckForException(clientResponse!);

            return IotaSDKResponse<ClientOutputsResponse>.CreateInstance(clientResponse);

        }
    }
}
