using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetTransaction
{
    internal class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<GetTransactionQueryModelData> _iotaSDKAccountModelCreator;

        public GetTransactionQueryHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<GetTransactionQueryModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<Transaction>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("getTransaction", request.AccountIndex, new GetTransactionQueryModelData(request.TransactionId));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
