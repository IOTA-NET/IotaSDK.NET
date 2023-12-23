using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetIncomingTransaction
{
    internal class GetIncomingTransactionQueryHandler : IRequestHandler<GetIncomingTransactionQuery, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetIncomingTransactionQueryModelData> _iotaSDKAccountModelCreator;

        public GetIncomingTransactionQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetIncomingTransactionQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(GetIncomingTransactionQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getIncomingTransaction", request.AccountIndex, new GetIncomingTransactionQueryModelData(request.TransactionId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
