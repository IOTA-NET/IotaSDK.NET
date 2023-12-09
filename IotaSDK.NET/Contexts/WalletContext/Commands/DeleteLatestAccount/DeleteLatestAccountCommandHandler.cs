using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.DeleteLatestAccount
{
    internal class DeleteLatestAccountCommandHandler : IRequestHandler<DeleteLatestAccountCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public DeleteLatestAccountCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(DeleteLatestAccountCommand request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("removeLatestAccount");
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response =  IotaSDKResponse<bool>.CreateInstance(walletResponse, type: "removeLatestAccount");

            response.Payload = true;
            return response;
        }
    }
}
