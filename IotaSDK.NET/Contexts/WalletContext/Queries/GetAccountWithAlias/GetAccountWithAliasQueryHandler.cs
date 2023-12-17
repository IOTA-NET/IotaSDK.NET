using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasQueryHandler : IRequestHandler<GetAccountWithAliasQuery, IotaSDKResponse<AccountMeta>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountWithAliasQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<AccountMeta>> Handle(GetAccountWithAliasQuery request, CancellationToken cancellationToken)
        {
            GetAccountWithAliasQueryModelData modelData = new GetAccountWithAliasQueryModelData(request.Alias);
            IotaSDKModel<GetAccountWithAliasQueryModelData> model = new IotaSDKModel<GetAccountWithAliasQueryModelData>("getAccount", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<AccountMeta>.CreateInstance(walletResponse);


            return response;
        }
    }
}
