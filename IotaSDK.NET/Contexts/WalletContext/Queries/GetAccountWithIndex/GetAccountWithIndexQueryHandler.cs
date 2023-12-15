using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexQueryHandler : IRequestHandler<GetAccountWithIndexQuery, IotaSDKResponse<AccountMeta>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetAccountWithIndexQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<AccountMeta>> Handle(GetAccountWithIndexQuery request, CancellationToken cancellationToken)
        {
            GetAccountWithIndexQueryModelData modelData = new GetAccountWithIndexQueryModelData(request.Index);
            IotaSDKModel<GetAccountWithIndexQueryModelData> model = new IotaSDKModel<GetAccountWithIndexQueryModelData>("getAccount", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            
            IotaSDKException.CheckForException(walletResponse!);

            return IotaSDKResponse<AccountMeta>.CreateInstance(walletResponse);

        }
    }
}
