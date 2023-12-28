using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias
{
    internal class PrepareDestroyAliasCommandHandler : IRequestHandler<PrepareDestroyAliasCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareDestroyAliasCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareDestroyAliasCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareDestroyAliasCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareDestroyAliasCommand request, CancellationToken cancellationToken)
        {
            PrepareDestroyAliasCommandInnerModelData innerModelData = new PrepareDestroyAliasCommandInnerModelData(new List<string> { request.AliasId });
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareBurn", request.AccountIndex, new PrepareDestroyAliasCommandModelData(innerModelData, request.TransactionOptions));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
