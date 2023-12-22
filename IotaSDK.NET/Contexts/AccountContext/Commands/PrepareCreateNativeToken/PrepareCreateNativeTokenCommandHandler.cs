using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeToken
{
    internal class PrepareCreateNativeTokenCommandHandler : IRequestHandler<PrepareCreateNativeTokenCommand, IotaSDKResponse<PreparedNativeTokenTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareCreateNativeTokenCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareCreateNativeTokenCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareCreateNativeTokenCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedNativeTokenTransactionData>> Handle(PrepareCreateNativeTokenCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareCreateNativeToken", request.AccountIndex, new PrepareCreateNativeTokenCommandModelData(request.NativeTokenCreationOptions, request.TransactionOptions));
            var json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedNativeTokenTransactionData>.CreateInstance(accountResponse);
        }
    }
}
