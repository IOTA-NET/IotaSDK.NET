using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.ClearStrongholdPassword
{
    internal class ClearStrongholdPasswordCommandHandler : IRequestHandler<ClearStrongholdPasswordCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public ClearStrongholdPasswordCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<bool>> Handle(ClearStrongholdPasswordCommand request, CancellationToken cancellationToken)
        {
            IotaSDKModel model = new IotaSDKModel("clearStrongholdPassword");
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(walletResponse, type: "clearStrongholdPassword");
            response.Payload = true;

            return response;
        }
    }
}
