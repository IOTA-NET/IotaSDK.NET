using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetClientOptions
{
    internal class SetClientOptionsCommandHandler : IRequestHandler<SetClientOptionsCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public SetClientOptionsCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(SetClientOptionsCommand request, CancellationToken cancellationToken)
        {
            SetClientOptionsCommandModelData modelData = new SetClientOptionsCommandModelData(request.ClientOptions);
            IotaSDKModel<SetClientOptionsCommandModelData> model = new IotaSDKModel<SetClientOptionsCommandModelData>("setClientOptions", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            return new IotaSDKResponse<bool>("setClientOptions") { Payload = true };
        }
    }
}
