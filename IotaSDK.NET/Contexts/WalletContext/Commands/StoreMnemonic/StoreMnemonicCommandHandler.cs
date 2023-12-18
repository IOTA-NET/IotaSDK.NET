using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StoreMnemonic
{
    internal class StoreMnemonicCommandHandler : IRequestHandler<StoreMnemonicCommand>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly RustBridgeCommon _rustBridgeCommon;

        public StoreMnemonicCommandHandler(RustBridgeWallet rustBridgeWallet, RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _rustBridgeCommon = rustBridgeCommon;
        }
        public async Task Handle(StoreMnemonicCommand request, CancellationToken cancellationToken)
        {
            StoreMnemonicCommandModelData modelData = new StoreMnemonicCommandModelData(request.Mnemonic);
            IotaSDKModel<StoreMnemonicCommandModelData> model
                = new IotaSDKModel<StoreMnemonicCommandModelData>("storeMnemonic", modelData);
            string json = model.AsJson();

            await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            string error = await _rustBridgeCommon.GetLastErrorAsync();
        }
    }
}
