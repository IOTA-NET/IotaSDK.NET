using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.ParticipationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationOverview
{
    internal class GetParticipationOverviewQueryHandler : IRequestHandler<GetParticipationOverviewQuery, IotaSDKResponse<ParticipationOverview>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetParticipationOverviewModelData> _iotaSDKAccountModelCreator;

        public GetParticipationOverviewQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetParticipationOverviewModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<ParticipationOverview>> Handle(GetParticipationOverviewQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getParticipationOverview", request.AccountIndex, new GetParticipationOverviewModelData(request.ParticipationEventIds));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<ParticipationOverview>.CreateInstance(accountResponse);
        }
    }
}
