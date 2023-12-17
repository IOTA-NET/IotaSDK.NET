using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft
{
    internal class PrepareBurnNftCommandHandler : IRequestHandler<PrepareBurnNftCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public PrepareBurnNftCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareBurnNftCommand request, CancellationToken cancellationToken)
        {
            PrepareBurnNftCommandModelDataBurn innerModelDataBurn = new PrepareBurnNftCommandModelDataBurn(new List<string> { request.NftId });
            PrepareBurnNftCommandModelData innerModelData = new PrepareBurnNftCommandModelData(innerModelDataBurn, request.TransactionOptions);
            IotaSDKModel<PrepareBurnNftCommandModelData> innerModel = new IotaSDKModel<PrepareBurnNftCommandModelData>("prepareBurn", innerModelData);
            AccountModelData<PrepareBurnNftCommandModelData> accountModelData = new AccountModelData<PrepareBurnNftCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<PrepareBurnNftCommandModelData> accountModel = new IotaSDKAccountModel<PrepareBurnNftCommandModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
