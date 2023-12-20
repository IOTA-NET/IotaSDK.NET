using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetPendingTransactions
{
    internal class GetPendingTransactionsQueryHandler : IRequestHandler<GetPendingTransactionsQuery, IotaSDKResponse<List<Transaction>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator _iotaSDKAccountModelCreator;

        public GetPendingTransactionsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<List<Transaction>>> Handle(GetPendingTransactionsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("pendingTransactions", request.AccountIndex);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<Transaction>>.CreateInstance(accountResponse);
        }
    }
}
