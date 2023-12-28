using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Signatures;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignTransactionEssence
{
    internal class SignTransactionEssenceCommandHandler : IRequestHandler<SignTransactionEssenceCommand, IotaSDKResponse<SignedTransactionEssence>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SignTransactionEssenceCommandModelData> _iotaSDKAccountModelCreator;

        public SignTransactionEssenceCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SignTransactionEssenceCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<SignedTransactionEssence>> Handle(SignTransactionEssenceCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("signTransactionEssence", request.AccountIndex, new SignTransactionEssenceCommandModelData(request.PreparedTransactionData));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<SignedTransactionEssence>.CreateInstance(accountResponse);
        }
    }
}
