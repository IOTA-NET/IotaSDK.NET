using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StartBackgroundSync
{
    internal class StartBackgroundSyncCommandHandler : IRequestHandler<StartBackgroundSyncCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public StartBackgroundSyncCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(StartBackgroundSyncCommand request, CancellationToken cancellationToken)
        {
            StartBackgroundSyncCommandModelData modelData = new StartBackgroundSyncCommandModelData(request.SyncOptions, request.IntervalInMilliseconds);
            IotaSDKModel<StartBackgroundSyncCommandModelData> model = new IotaSDKModel<StartBackgroundSyncCommandModelData>("startBackgroundSync", modelData);
            string json = model.AsJson();


            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return new IotaSDKResponse<bool>("startBackgroundSync") { Payload = true };
        }
    }
}
