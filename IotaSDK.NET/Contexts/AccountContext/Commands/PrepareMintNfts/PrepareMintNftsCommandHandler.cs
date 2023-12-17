using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNfts
{
    internal class PrepareMintNftsCommandHandler : IRequestHandler<PrepareMintNftsCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;

        public PrepareMintNftsCommandHandler(RustBridgeWallet rustBridgeWallet)
        {
            _rustBridgeWallet = rustBridgeWallet;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareMintNftsCommand request, CancellationToken cancellationToken)
        {
            PrepareMintNftsCommandModelData innerModelData = new PrepareMintNftsCommandModelData(request.NftOptionsList, request.TransactionOptions);
            IotaSDKModel<PrepareMintNftsCommandModelData> innerModel = new IotaSDKModel<PrepareMintNftsCommandModelData>("prepareMintNfts", innerModelData);
            AccountModelData<PrepareMintNftsCommandModelData> accountModelData = new AccountModelData<PrepareMintNftsCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<PrepareMintNftsCommandModelData> accountModel = new IotaSDKAccountModel<PrepareMintNftsCommandModelData>(accountModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
