using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexCommandHandler : IRequestHandler<GetAccountWithIndexQuery, IotaSDKResponse<IAccount>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountWithIndexCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<IAccount>> Handle(GetAccountWithIndexQuery request, CancellationToken cancellationToken)
        {
            GetAccountWithIndexCommandModelData modelData = new GetAccountWithIndexCommandModelData(request.Index);
            IotaSDKModel<GetAccountWithIndexCommandModelData> model = new IotaSDKModel<GetAccountWithIndexCommandModelData>("getAccount", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            
            IotaSDKException.CheckForException(walletResponse!);

            IotaSDKResponse<AccountMeta> response = IotaSDKResponse<AccountMeta>.CreateInstance(walletResponse);

            IAccount account = new Account(response.Payload.Index, response.Payload.Alias);

            var newResponse = new IotaSDKResponse<IAccount>("getAccount");
            newResponse.Payload = account;

            return newResponse;
        }
    }
}
