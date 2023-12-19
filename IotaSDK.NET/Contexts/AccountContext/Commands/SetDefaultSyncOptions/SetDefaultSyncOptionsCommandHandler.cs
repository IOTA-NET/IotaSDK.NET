using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetDefaultSyncOptions
{
    internal class SetDefaultSyncOptionsCommandHandler : IRequestHandler<SetDefaultSyncOptionsCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SetDefaultSyncOptionsCommandModelData> _iotaSDKAccountModelCreator;

        public SetDefaultSyncOptionsCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SetDefaultSyncOptionsCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task Handle(SetDefaultSyncOptionsCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("setDefaultSyncOptions", request.AccountIndex, new SetDefaultSyncOptionsCommandModelData(request.SyncOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            IotaSDKException.CheckForException(accountResponse!);
        }
    }
}


