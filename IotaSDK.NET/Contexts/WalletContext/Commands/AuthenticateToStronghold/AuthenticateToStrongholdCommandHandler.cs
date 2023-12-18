using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold
{
    internal class AuthenticateToStrongholdCommandHandler : IRequestHandler<AuthenticateToStrongholdCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public AuthenticateToStrongholdCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(AuthenticateToStrongholdCommand request, CancellationToken cancellationToken)
        {
            AuthenticateToStrongholdCommandModelData modelData = new AuthenticateToStrongholdCommandModelData(request.Password);
            IotaSDKModel<AuthenticateToStrongholdCommandModelData> model = new IotaSDKModel<AuthenticateToStrongholdCommandModelData>("setStrongholdPassword", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            IotaSDKResponse<bool> response = IotaSDKResponse<bool>.CreateInstance(walletResponse, type: "setStrongholdPassword");

            response.Payload = true;

            return response;

        }
    }
}
