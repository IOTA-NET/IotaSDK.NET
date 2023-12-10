using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasCommandHandler : IRequestHandler<GetAccountWithAliasCommand, IotaSDKResponse<IAccount>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountWithAliasCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<IAccount>> Handle(GetAccountWithAliasCommand request, CancellationToken cancellationToken)
        {
            GetAccountWithAliasCommandModelData modelData = new GetAccountWithAliasCommandModelData(request.Alias);
            IotaSDKModel<GetAccountWithAliasCommandModelData> model = new IotaSDKModel<GetAccountWithAliasCommandModelData>("getAccount", modelData);
            string json = model.AsJson();

            string? walletResponse =  await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            
            IotaSDKException.CheckForException(walletResponse!);

            var accountMetaResponse =  IotaSDKResponse<AccountMeta>.CreateInstance(walletResponse);

            IAccount account = new Account(accountMetaResponse.Payload.Index, accountMetaResponse.Payload.Alias);

            IotaSDKResponse<IAccount> response = new IotaSDKResponse<IAccount>("getAccount");
            response.Payload = account;

            return response;    
        }
    }
}
