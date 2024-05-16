using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetOutputs
{
    internal class GetOutputsQueryHandler : IRequestHandler<GetOutputsQuery, IotaSDKResponse<List<ClientOutputResponse>>>
    {
        private readonly RustBridgeClient _rustBridgeClient;

        public GetOutputsQueryHandler(RustBridgeClient rustBridgeClient)
        {
            _rustBridgeClient = rustBridgeClient;
        }

        public async Task<IotaSDKResponse<List<ClientOutputResponse>>> Handle(GetOutputsQuery request, CancellationToken cancellationToken)
        {
            var modelData = new GetOutputsQueryModelData(request.OutputIds);
            var model = new IotaSDKModel<GetOutputsQueryModelData>("getOutputs", modelData);
            var json = model.AsJson();

            string? clientResponse = await _rustBridgeClient.CallClientMethodAsync(request.ClientHandle, json);

            IotaSDKException.CheckForException(clientResponse!);

            return IotaSDKResponse<List<ClientOutputResponse>>.CreateInstance(clientResponse);
        }
    }
}
