using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeTokens
{
    internal class PrepareCreateNativeTokensCommandHandler : IRequestHandler<PrepareCreateNativeTokensCommand, IotaSDKResponse<PreparedNativeTokenTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareCreateNativeTokensCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareCreateNativeTokensCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareCreateNativeTokensCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedNativeTokenTransactionData>> Handle(PrepareCreateNativeTokensCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareCreateNativeToken", request.AccountIndex, new PrepareCreateNativeTokensCommandModelData(request.NativeTokenCreationOptions, request.TransactionOptions));
            var json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            var x = IotaSDKResponse<PreparedNativeTokenTransactionData>.CreateInstance(accountResponse);

            var check = JsonConvert.SerializeObject(x.Payload);

            return x;
        }
    }
}
