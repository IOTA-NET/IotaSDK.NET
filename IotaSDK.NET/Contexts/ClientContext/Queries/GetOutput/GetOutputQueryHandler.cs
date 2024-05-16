using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Outputs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetOutput
{
    internal class GetOutputQueryHandler : IRequestHandler<GetOutputQuery, IotaSDKResponse<ClientOutputResponse>>
    {
        private readonly RustBridgeClient _rustBridgeClient;

        public GetOutputQueryHandler(RustBridgeClient rustBridgeClient)
        {
            _rustBridgeClient = rustBridgeClient;
        }

        public async Task<IotaSDKResponse<ClientOutputResponse>> Handle(GetOutputQuery request, CancellationToken cancellationToken)
        {
            GetOutputQueryModelData modelData = new GetOutputQueryModelData(request.OutputId);
            var model = new IotaSDKModel<GetOutputQueryModelData>("getOutput", modelData);
            string json = model.AsJson();

            string? clientResponse = await _rustBridgeClient.CallClientMethodAsync(request.ClientHandle, json);

            var r = IotaSDKResponse < ClientOutputResponse >.CreateInstance(clientResponse);

            return r;
        }
    }
}
