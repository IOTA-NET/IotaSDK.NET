using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction
{
    internal class SignAndSubmitTransactionCommandHandler : IRequestHandler<SignAndSubmitTransactionCommand, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public SignAndSubmitTransactionCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SignAndSubmitTransactionCommand request, CancellationToken cancellationToken)
        {
            SignAndSubmitTransactionCommandModelData innerModelData = new SignAndSubmitTransactionCommandModelData(request.PreparedTransactionData);
            IotaSDKModel<SignAndSubmitTransactionCommandModelData> innerModel = new IotaSDKModel<SignAndSubmitTransactionCommandModelData>("signAndSubmitTransaction", innerModelData);
            AccountModelData<SignAndSubmitTransactionCommandModelData> accountModelData = new AccountModelData<SignAndSubmitTransactionCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<SignAndSubmitTransactionCommandModelData> accountModel = new IotaSDKAccountModel<SignAndSubmitTransactionCommandModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            
            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
