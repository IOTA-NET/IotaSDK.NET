using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.UnregisterParticipationEvent
{
    internal class UnregisterParticipationEventCommandHandler : IRequestHandler<UnregisterParticipationEventCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<UnregisterParticipationEventCommandModelData> _iotaSDKAccountModelCreator;

        public UnregisterParticipationEventCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<UnregisterParticipationEventCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task Handle(UnregisterParticipationEventCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("deregisterParticipationEvent", request.AccountIndex, new UnregisterParticipationEventCommandModelData(request.ParticipationEventId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);
        }
    }
}
