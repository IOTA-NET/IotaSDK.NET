using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.ChangeStrongholdPassword
{
    internal class ChangeStrongholdPasswordCommandHandler : IRequestHandler<ChangeStrongholdPasswordCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public ChangeStrongholdPasswordCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<bool>> Handle(ChangeStrongholdPasswordCommand request, CancellationToken cancellationToken)
        {
            ChangeStrongholdPasswordCommandModelData modelData = new ChangeStrongholdPasswordCommandModelData(request.CurrentPassword, request.NewPassword);
            IotaSDKModel<ChangeStrongholdPasswordCommandModelData> model = new IotaSDKModel<ChangeStrongholdPasswordCommandModelData>("changeStrongholdPassword", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(walletResponse, type: "changeStrongholdPassword");
            response.Payload = true;

            return response;

        }
    }
}
