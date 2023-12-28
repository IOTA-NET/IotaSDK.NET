using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareClaimOutputs
{
    internal class PrepareClaimOutputsCommandHandler : IRequestHandler<PrepareClaimOutputsCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareClaimOutputsCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareClaimOutputsCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareClaimOutputsCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }
        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareClaimOutputsCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareClaimOutputs", request.AccountIndex, new PrepareClaimOutputsCommandModelData(request.OutputIds));
            var json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
