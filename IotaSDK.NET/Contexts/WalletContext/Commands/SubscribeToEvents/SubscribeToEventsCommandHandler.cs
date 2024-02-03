using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Events;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SubscribeToEvents
{
    internal class SubscribeToEventsCommandHandler : IRequestHandler<SubscribeToEventsCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public SubscribeToEventsCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<bool>> Handle(SubscribeToEventsCommand request, CancellationToken cancellationToken)
        {
            List<int> eventNames = WalletEventFlagConverter.ConvertWalletEventTypeToInt(request.WalletEventType);

            string eventsAsJsonArray = JsonConvert.SerializeObject(eventNames);

            bool? listenResponse = await _rustBridgeWallet.ListenWalletAsync(request.WalletHandle, eventsAsJsonArray, request.Callback);

            bool success = false;
            if (listenResponse.HasValue && listenResponse.Value)
                success = true;

            return new IotaSDKResponse<bool>("SubscribeToEvents") { Payload = success };
        }
    }
}
