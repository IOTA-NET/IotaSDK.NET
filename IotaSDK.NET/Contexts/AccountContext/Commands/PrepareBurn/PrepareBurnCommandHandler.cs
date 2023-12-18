using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn
{
    internal class PrepareBurnCommandHandler : IRequestHandler<PrepareBurnCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public PrepareBurnCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareBurnCommand request, CancellationToken cancellationToken)
        {
            PrepareBurnCommandModelData innerModelData = new PrepareBurnCommandModelData(request.BurnIds, request.TransactionOptions);
            IotaSDKModel<PrepareBurnCommandModelData> innerModel = new IotaSDKModel<PrepareBurnCommandModelData>("prepareBurn", innerModelData);
            AccountModelData<PrepareBurnCommandModelData> accountModelData = new AccountModelData<PrepareBurnCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<PrepareBurnCommandModelData> accountModel = new IotaSDKAccountModel<PrepareBurnCommandModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
