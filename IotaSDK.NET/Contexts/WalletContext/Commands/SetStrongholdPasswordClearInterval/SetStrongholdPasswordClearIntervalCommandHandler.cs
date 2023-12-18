using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.SetStrongholdPasswordClearInterval
{
    internal class SetStrongholdPasswordClearIntervalCommandHandler : IRequestHandler<SetStrongholdPasswordClearIntervalCommand, IotaSDKResponse<bool>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public SetStrongholdPasswordClearIntervalCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<bool>> Handle(SetStrongholdPasswordClearIntervalCommand request, CancellationToken cancellationToken)
        {
            SetStrongholdPasswordClearIntervalCommandModelData modelData = new SetStrongholdPasswordClearIntervalCommandModelData(request.IntervalInMilliSeconds);
            IotaSDKModel<SetStrongholdPasswordClearIntervalCommandModelData> model = new IotaSDKModel<SetStrongholdPasswordClearIntervalCommandModelData>("setStrongholdPasswordClearInterval", modelData);
            string json = model.AsJson();

            string? walletResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(walletResponse!);

            var response = IotaSDKResponse<bool>.CreateInstance(walletResponse, "setStrongholdPasswordClearInterval");
            response.Payload = true;

            return response;

        }
    }
}
