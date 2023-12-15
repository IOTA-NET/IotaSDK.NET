using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias
{
    internal class SetAliasCommandHandler : IRequestHandler<SetAliasCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public SetAliasCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task Handle(SetAliasCommand request, CancellationToken cancellationToken)
        {
            SetAliasCommandModelData innerModelData = new SetAliasCommandModelData(request.Alias);
            IotaSDKModel<SetAliasCommandModelData> innerModel = new IotaSDKModel<SetAliasCommandModelData>("setAlias", innerModelData);
            AccountModelData<SetAliasCommandModelData> accountModelData = new AccountModelData<SetAliasCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<SetAliasCommandModelData> model = new IotaSDKAccountModel<SetAliasCommandModelData>(accountModelData);
            string json = model.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

        }
    }
}
