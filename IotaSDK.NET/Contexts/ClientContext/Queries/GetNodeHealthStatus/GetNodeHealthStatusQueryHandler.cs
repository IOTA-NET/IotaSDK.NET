using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNodeHealthStatus
{
    internal class GetNodeHealthStatusQueryHandler : IRequestHandler<GetNodeHealthStatusQuery, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeClient _client;

        public GetNodeHealthStatusQueryHandler(RustBridgeClient client)
        {
            _client = client;
        }

        public async Task<IotaSDKResponse<bool>> Handle(GetNodeHealthStatusQuery request, CancellationToken cancellationToken)
        {
            var modelData = new GetNodeHealthStatusQueryModelData(request.Url);
            var model = new IotaSDKModel<GetNodeHealthStatusQueryModelData>("getHealth", modelData);
            var json = model.AsJson();

            string? clientResponse = await _client.CallClientMethodAsync(request.ClientHandle, json);

            IotaSDKException.CheckForException(clientResponse!);

            return IotaSDKResponse<bool>.CreateInstance(clientResponse);
        }
    }
}
