using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.ParticipationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RegisterParticipationEvents
{
    internal class RegisterParticipationEventsCommandHandler : IRequestHandler<RegisterParticipationEventsCommand, IotaSDKResponse<ParticipationEventMap>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<RegisterParticipationEventsCommandModelData> _iotaSDKAccountModelCreator;

        public RegisterParticipationEventsCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<RegisterParticipationEventsCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<ParticipationEventMap>> Handle(RegisterParticipationEventsCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("registerParticipationEvents", request.AccountIndex, new RegisterParticipationEventsCommandModelData(request.ParticipationEventRegistrationOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<ParticipationEventMap>.CreateInstance(accountResponse);
        }
    }
}
