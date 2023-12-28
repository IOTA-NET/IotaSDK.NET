using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs
{
    internal class GetClaimableOutputsQueryHandler : IRequestHandler<GetClaimableOutputsQuery, IotaSDKResponse<List<string>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetClaimableOutputsQueryModelData> _iotaSDKAccountModelCreator;

        public GetClaimableOutputsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetClaimableOutputsQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<List<string>>> Handle(GetClaimableOutputsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("claimableOutputs", request.AccountIndex, new GetClaimableOutputsQueryModelData(request.ClaimableOutputType.ToString()));
            var json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<string>>.CreateInstance(accountResponse);
        }
    }
}
