using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountIndexes
{
    internal class GetAccountIndexesQueryHandler : IRequestHandler<GetAccountIndexesQuery, IotaSDKResponse<List<int>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountIndexesQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }


        public async Task<IotaSDKResponse<List<int>>> Handle(GetAccountIndexesQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("getAccountIndexes");
            string json = model.AsJson();

            string? walletResponse =  await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return IotaSDKResponse<List<int>>.CreateInstance(walletResponse);
        }
    }
}
