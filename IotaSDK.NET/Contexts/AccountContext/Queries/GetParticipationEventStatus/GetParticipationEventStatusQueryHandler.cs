using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.ParticipationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventStatus
{
    internal class GetParticipationEventStatusQueryHandler : IRequestHandler<GetParticipationEventStatusQuery, IotaSDKResponse<ParticipationEventStatus>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetParticipationEventStatusQueryModelData> _iotaSDKAccountModelCreator;

        public GetParticipationEventStatusQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetParticipationEventStatusQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<ParticipationEventStatus>> Handle(GetParticipationEventStatusQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getParticipationEventStatus", request.AccountIndex, new GetParticipationEventStatusQueryModelData(request.ParticipationEventId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            return IotaSDKResponse<ParticipationEventStatus>.CreateInstance(accountResponse!);
        }
    }
}
