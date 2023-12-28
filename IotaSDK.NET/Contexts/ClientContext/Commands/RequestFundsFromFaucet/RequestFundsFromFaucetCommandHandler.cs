using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Faucet;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.ClientContext.Commands.RequestFundsFromFaucet
{
    internal class RequestFundsFromFaucetCommandHandler : IRequestHandler<RequestFundsFromFaucetCommand, IotaSDKResponse<FaucetResponse>>
    {
        private readonly RustBridgeClient _rustBridgeClient;

        public RequestFundsFromFaucetCommandHandler(RustBridgeClient rustBridgeClient)
        {
            _rustBridgeClient = rustBridgeClient;
        }
        public async Task<IotaSDKResponse<FaucetResponse>> Handle(RequestFundsFromFaucetCommand request, CancellationToken cancellationToken)
        {
            var modelData = new RequestFundsFromFaucetCommandModelData(request.FaucetUrl, request.Bech32Address);
            var model = new IotaSDKModel<RequestFundsFromFaucetCommandModelData>("requestFundsFromFaucet", modelData);
            string json = model.AsJson();

            string? clientResponse = await _rustBridgeClient.CallClientMethodAsync(request.ClientHandle, json);
            IotaSDKException.CheckForException(clientResponse!);
            //For some reason, faucet response is double encoded

            var outerResponse = IotaSDKResponse<string>.CreateInstance(clientResponse);
            var innerResponse = JsonConvert.DeserializeObject<FaucetResponse>(outerResponse.Payload);

            return new IotaSDKResponse<FaucetResponse>(outerResponse.Type) { Payload = innerResponse! };
        }
    }
}
