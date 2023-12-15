using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin
{
    internal class SendBaseCoinCommandHandler : IRequestHandler<SendBaseCoinCommand, IotaSDKResponse<Transaction>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly RustBridgeCommon _rustBridgeCommon;

        public SendBaseCoinCommandHandler(RustBridgeWallet rustBridgeWallet, RustBridgeCommon rustBridgeCommon)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _rustBridgeCommon = rustBridgeCommon;
        }

        public async Task<IotaSDKResponse<Transaction>> Handle(SendBaseCoinCommand request, CancellationToken cancellationToken)
        {
            SendBaseCoinCommandModelData innerModelData = new SendBaseCoinCommandModelData(request.Amount, request.Bech32ReceiverAddress, request.TransactionOptions);
            IotaSDKModel<SendBaseCoinCommandModelData> innerModel = new IotaSDKModel<SendBaseCoinCommandModelData>("send", innerModelData);
            AccountModelData<SendBaseCoinCommandModelData> accountModelData = new AccountModelData<SendBaseCoinCommandModelData>(request.AccountIndex, innerModel);
            IotaSDKAccountModel<SendBaseCoinCommandModelData> model = new IotaSDKAccountModel<SendBaseCoinCommandModelData>(accountModelData);
            string json = model.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);
            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<Transaction>.CreateInstance(accountResponse);
        }
    }
}
