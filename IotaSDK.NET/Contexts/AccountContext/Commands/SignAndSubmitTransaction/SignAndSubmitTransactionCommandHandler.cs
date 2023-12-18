using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
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
        private readonly RustBridgeCommon _rustBridgeCommon;

        public SignAndSubmitTransactionCommandHandler(RustBridgeWallet rustBridgeWallet, RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _rustBridgeCommon = rustBridgeCommon;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(SignAndSubmitTransactionCommand request, CancellationToken cancellationToken)
        {
            SignAndSubmitTransactionCommandModelData innerModelData = new SignAndSubmitTransactionCommandModelData(request.PreparedTransactionData);
            IotaSDKModel<SignAndSubmitTransactionCommandModelData> innerModel = new IotaSDKModel<SignAndSubmitTransactionCommandModelData>("signAndSubmitTransaction", innerModelData);
            AccountModelData<SignAndSubmitTransactionCommandModelData> accountModelData = new AccountModelData<SignAndSubmitTransactionCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<SignAndSubmitTransactionCommandModelData> accountModel = new IotaSDKAccountModel<SignAndSubmitTransactionCommandModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            string err = await _rustBridgeCommon.GetLastErrorAsync();

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
