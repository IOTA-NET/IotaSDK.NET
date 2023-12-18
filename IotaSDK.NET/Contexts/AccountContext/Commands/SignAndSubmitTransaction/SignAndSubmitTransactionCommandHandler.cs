using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction
{
    internal class SignAndSubmitTransactionCommandHandler : IRequestHandler<SignAndSubmitTransactionCommand, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<SignAndSubmitTransactionCommandModelData> _iotaSDKAccountModelCreator;

        public SignAndSubmitTransactionCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<SignAndSubmitTransactionCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(SignAndSubmitTransactionCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("signAndSubmitTransaction", request.AccountIndex, new SignAndSubmitTransactionCommandModelData(request.PreparedTransactionData));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
