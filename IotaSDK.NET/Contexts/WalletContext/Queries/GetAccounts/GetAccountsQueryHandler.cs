using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts
{
    internal class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IotaSDKResponse<List<AccountMeta>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountsQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<List<AccountMeta>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("getAccounts");
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var listOfAccountMetaResponse = IotaSDKResponse<List<AccountMeta>>.CreateInstance(walletResponse);

            return listOfAccountMetaResponse;
        }

    }
}
