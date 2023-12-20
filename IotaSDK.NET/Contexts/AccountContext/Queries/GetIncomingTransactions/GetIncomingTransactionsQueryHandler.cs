using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransactions
{
    internal class GetIncomingTransactionsQueryHandler : IRequestHandler<GetIncomingTransactionsQuery, IotaSDKResponse<List<Transaction>>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator _iotaSDKAccountModelCreator;

        public GetIncomingTransactionsQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<List<Transaction>>> Handle(GetIncomingTransactionsQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("incomingTransactions", request.AccountIndex);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<List<Transaction>>.CreateInstance(accountResponse);
        }
    }
}
