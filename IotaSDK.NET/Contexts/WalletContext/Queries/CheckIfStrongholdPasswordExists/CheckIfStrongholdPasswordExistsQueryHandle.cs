using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.CheckIfStrongholdPasswordExists
{
    internal class CheckIfStrongholdPasswordExistsQueryHandle : IRequestHandler<CheckIfStrongholdPasswordExistsQuery, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public CheckIfStrongholdPasswordExistsQueryHandle(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<bool>> Handle(CheckIfStrongholdPasswordExistsQuery request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("isStrongholdPasswordAvailable");
            string json = model.AsJson();
            string? walletResponse =  await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return IotaSDKResponse<bool>.CreateInstance(walletResponse);
        }
    }
}
