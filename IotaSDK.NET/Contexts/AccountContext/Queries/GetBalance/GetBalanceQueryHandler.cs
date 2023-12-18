using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetBalance
{
    internal class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, IotaSDKResponse<AccountBalance>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public GetBalanceQueryHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<AccountBalance>> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel innerModel = new IotaSDKModel("getBalance");
            AccountModelData accountModelData = new AccountModelData(request.AccountIndex, innerModel);
            IotaSDKAccountModel accountModel = new IotaSDKAccountModel(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<AccountBalance>.CreateInstance(accountResponse);
        }
    }
}
