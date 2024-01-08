using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.BackupStronghold
{
    internal class BackupStrongholdCommandHandler : IRequestHandler<BackupStrongholdCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public BackupStrongholdCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<bool>> Handle(BackupStrongholdCommand request, CancellationToken cancellationToken)
        {
            BackupStrongholdCommandModelData modelData = new BackupStrongholdCommandModelData(request.DestinationPath, request.Password);
            IotaSDKModel<BackupStrongholdCommandModelData> model = new IotaSDKModel<BackupStrongholdCommandModelData>("backup", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(walletResponse, "backup");
            response.Payload = true;

            return response;
        }
    }
}
