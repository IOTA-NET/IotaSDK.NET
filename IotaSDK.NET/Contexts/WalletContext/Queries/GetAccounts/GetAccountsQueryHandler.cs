using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts
{
    internal class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IotaSDKResponse<List<IAccount>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountsQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<List<IAccount>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("getAccounts");
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var listOfAccountMetaResponse = IotaSDKResponse<List<AccountMeta>>.CreateInstance(walletResponse);
            var accountMetas = listOfAccountMetaResponse.Payload;

            List<IAccount> accounts = accountMetas.Select(accountMeta =>
                new Account(accountMeta.Index, accountMeta.Alias) as IAccount).ToList();

            var listOfAccountsResponse = new IotaSDKResponse<List<IAccount>>(listOfAccountMetaResponse.Type)
            {
                Payload = accounts
            };

            return listOfAccountsResponse;
        }

    }
}
