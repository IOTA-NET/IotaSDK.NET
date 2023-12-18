using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
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
        private readonly IotaSDKAccountModelCreator<PrepareBurnNftCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareBurnNftCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareBurnNftCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareBurnNftCommand request, CancellationToken cancellationToken)
        {
            PrepareBurnNftCommandModelDataBurn innerModelDataBurn = new PrepareBurnNftCommandModelDataBurn(new List<string> { request.NftId });
            PrepareBurnNftCommandModelData innerModelData = new PrepareBurnNftCommandModelData(innerModelDataBurn, request.TransactionOptions);
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareBurn", request.AccountIndex, innerModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
