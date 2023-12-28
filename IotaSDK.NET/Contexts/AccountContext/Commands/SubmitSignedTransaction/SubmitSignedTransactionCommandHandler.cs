using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SubmitSignedTransaction
{
    internal class SubmitSignedTransactionCommandHandler : IRequestHandler<SubmitSignedTransactionCommand, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SubmitSignedTransactionCommandModelData> _iotaSDKAccountModelCreator;

        public SubmitSignedTransactionCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SubmitSignedTransactionCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SubmitSignedTransactionCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("submitAndStoreTransaction", request.AccountIndex, new SubmitSignedTransactionCommandModelData(request.SignedTransactionEssence));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
