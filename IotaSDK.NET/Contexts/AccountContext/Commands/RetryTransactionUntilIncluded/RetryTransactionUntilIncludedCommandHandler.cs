using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RetryTransactionUntilIncluded
{
    internal class RetryTransactionUntilIncludedCommandHandler : IRequestHandler<RetryTransactionUntilIncludedCommand, IotaSDKResponse<string>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<RetryTransactionUntilIncludedCommandModelData> _iotaSDKAccountModelCreator;

        public RetryTransactionUntilIncludedCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<RetryTransactionUntilIncludedCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<string>> Handle(RetryTransactionUntilIncludedCommand request, CancellationToken cancellationToken)
        {
            var innerModelData = new RetryTransactionUntilIncludedCommandModelData(request.TransactionId, request.Interval, request.MaxAttempts);
            var accountModel = _iotaSDKAccountModelCreator.Create("retryTransactionUntilIncluded", request.AccountIndex, innerModelData);
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<string>.CreateInstance(accountResponse);
        }
    }
}
