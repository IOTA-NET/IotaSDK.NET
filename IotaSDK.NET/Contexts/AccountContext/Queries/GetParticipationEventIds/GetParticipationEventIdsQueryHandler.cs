using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventIds
{
    internal class GetParticipationEventIdsQueryHandler : IRequestHandler<GetParticipationEventIdsQuery, IotaSDKResponse<List<string>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetParticipationEventIdsQueryModelData> _iotaSDKAccountModelCreator;

        public GetParticipationEventIdsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetParticipationEventIdsQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<List<string>>> Handle(GetParticipationEventIdsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getParticipationEventIds", request.AccountIndex, new GetParticipationEventIdsQueryModelData(request.Node, request.EventType));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<string>>.CreateInstance(accountResponse);
        }
    }
}
