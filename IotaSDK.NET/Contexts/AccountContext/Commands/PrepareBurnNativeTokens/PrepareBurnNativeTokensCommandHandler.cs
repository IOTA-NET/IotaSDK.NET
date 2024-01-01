using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens
{
    internal class PrepareBurnNativeTokensCommandHandler : IRequestHandler<PrepareBurnNativeTokensCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareBurnNativeTokensCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareBurnNativeTokensCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareBurnNativeTokensCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareBurnNativeTokensCommand request, CancellationToken cancellationToken)
        {
            PrepareBurnNativeTokensCommandInnerModelData innerModelData = 
                new PrepareBurnNativeTokensCommandInnerModelData(new Dictionary<string, BigInteger> { { request.TokenId, request.NumberOfTokensToBurn } });

            PrepareBurnNativeTokensCommandModelData modelData = new PrepareBurnNativeTokensCommandModelData(innerModelData);

            var accountModel = _iotaSDKAccountModelCreator.Create("prepareBurn", request.AccountIndex, modelData);

            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
