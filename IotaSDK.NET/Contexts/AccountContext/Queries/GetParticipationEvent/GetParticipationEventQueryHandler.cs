using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.ParticipationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvent
{
    internal class GetParticipationEventQueryHandler : IRequestHandler<GetParticipationEventQuery, IotaSDKResponse<ParticipationEventWithNodes>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetParticipationEventQueryModelData> _iotaSDKAccountModelCreator;

        public GetParticipationEventQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetParticipationEventQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<ParticipationEventWithNodes>> Handle(GetParticipationEventQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getParticipationEvent", request.AccountIndex, new GetParticipationEventQueryModelData(request.ParticipationEventId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<ParticipationEventWithNodes>.CreateInstance(accountResponse);
        }
    }
}
