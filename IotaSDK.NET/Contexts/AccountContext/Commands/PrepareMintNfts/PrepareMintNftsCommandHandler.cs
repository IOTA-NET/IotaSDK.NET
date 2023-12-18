using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
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
        private readonly IotaSDKAccountModelCreator<PrepareMintNftsCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareMintNftsCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareMintNftsCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareMintNftsCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareMintNfts", request.AccountIndex, new PrepareMintNftsCommandModelData(request.NftOptionsList, request.TransactionOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
