using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.RestoreBackup
{
    internal class RestoreBackupCommandHandler : IRequestHandler<RestoreBackupCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public RestoreBackupCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(RestoreBackupCommand request, CancellationToken cancellationToken)
        {
            RestoreBackupCommandModel model = new RestoreBackupCommandModel(request.SourcePath, request.Password, request.IgnoreIfCoinTypeMismatch, request.IgnoreIfBech32Mismatch);
            IotaSDKModel<RestoreBackupCommandModel> iotaSDKModel = new IotaSDKModel<RestoreBackupCommandModel>("restoreBackup", model);
            string json = iotaSDKModel.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(walletResponse, type: "restoreBackup");
            response.Payload = true;

            return response;
        }
    }
}
