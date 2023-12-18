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

        public SyncCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<AccountBalance>> Handle(SyncCommand request, CancellationToken cancellationToken)
        {
            SyncCommandModelData syncCommandModelData = new SyncCommandModelData(request.SyncOptions);
            IotaSDKModel<SyncCommandModelData> innerModel = new IotaSDKModel<SyncCommandModelData>("sync", syncCommandModelData);
            AccountModelData<SyncCommandModelData> accountModelData = new AccountModelData<SyncCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<SyncCommandModelData> iotaSDKAccountModel = new IotaSDKAccountModel<SyncCommandModelData>(accountModelData);
            string json = iotaSDKAccountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<AccountBalance>.CreateInstance(accountResponse);
        }
    }
}
