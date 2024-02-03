using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Events;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.UnsubscribeToEvents
{
    internal class UnsubscribeToEventsCommandHandler : IRequestHandler<UnsubscribeToEventsCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public UnsubscribeToEventsCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task Handle(UnsubscribeToEventsCommand request, CancellationToken cancellationToken)
        {
            List<string> walletEventsToUnsubscribe = WalletEventFlagConverter.ConvertWalletEventTypeToStringsList(request.WalletEventType);
            var modelData = new UnsubscribeToEventsCommandModelData(walletEventsToUnsubscribe);
            var model = new IotaSDKModel<UnsubscribeToEventsCommandModelData>("clearListeners", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            
            IotaSDKException.CheckForException(walletResponse!);

        }
    }
}
