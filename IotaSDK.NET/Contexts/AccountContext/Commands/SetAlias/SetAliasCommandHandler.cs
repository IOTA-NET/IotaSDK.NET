using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SetAlias
{
    internal class SetAliasCommandHandler : IRequestHandler<SetAliasCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SetAliasCommandModelData> _iotaSDKAccountModelCreator;

        public SetAliasCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SetAliasCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task Handle(SetAliasCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("setAlias", request.AccountIndex, new SetAliasCommandModelData(request.Alias));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

        }
    }
}
