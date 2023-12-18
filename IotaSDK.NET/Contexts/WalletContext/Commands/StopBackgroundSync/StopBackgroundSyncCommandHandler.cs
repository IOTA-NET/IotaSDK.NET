using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StopBackgroundSync
{
    internal class StopBackgroundSyncCommandHandler : IRequestHandler<StopBackgroundSyncCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public StopBackgroundSyncCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(StopBackgroundSyncCommand request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("stopBackgroundSync");
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return new IotaSDKResponse<bool>("stopBackgroundSync") { Payload = true };
        }
    }
}
