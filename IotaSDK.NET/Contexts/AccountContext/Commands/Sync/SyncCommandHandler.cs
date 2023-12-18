using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.Sync
{
    internal class SyncCommandHandler : IRequestHandler<SyncCommand, IotaSDKResponse<AccountBalance>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SyncCommandModelData> _iotaSDKAccountModelCreator;

        public SyncCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SyncCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<AccountBalance>> Handle(SyncCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("sync", request.AccountIndex, new SyncCommandModelData(request.SyncOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<AccountBalance>.CreateInstance(accountResponse);
        }
    }
}
