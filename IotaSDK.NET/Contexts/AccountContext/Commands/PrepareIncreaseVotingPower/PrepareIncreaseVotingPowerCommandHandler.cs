using IotaSDK.NET.Common.Exceptions;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Transactions.Prepared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareIncreaseVotingPower
{
    internal class PrepareIncreaseVotingPowerCommandHandler : IRequestHandler<PrepareIncreaseVotingPowerCommand, IotaSDKResponse<PreparedTransactionData>>
    {
        private readonly RustBridgeWallet _rustBridgeWallet;
        private readonly IotaSDKAccountModelCreator<PrepareIncreaseVotingPowerCommandModelData> _iotaSDKAccountModelCreator;

        public PrepareIncreaseVotingPowerCommandHandler(RustBridgeWallet rustBridgeWallet, IotaSDKAccountModelCreator<PrepareIncreaseVotingPowerCommandModelData> iotaSDKAccountModelCreator)
        {
            _rustBridgeWallet = rustBridgeWallet;
            _iotaSDKAccountModelCreator = iotaSDKAccountModelCreator;
        }

        public async Task<IotaSDKResponse<PreparedTransactionData>> Handle(PrepareIncreaseVotingPowerCommand request, CancellationToken cancellationToken)
        {
            var accountModel = _iotaSDKAccountModelCreator.Create("prepareIncreaseVotingPower", request.AccountIndex, new PrepareIncreaseVotingPowerCommandModelData(request.VotingPower.ToString()));
            string json = accountModel.AsJson();

            string? accountResponse = await _rustBridgeWallet.CallWalletMethodAsync(request.WalletHandle, json);

            IotaSDKException.CheckForException(accountResponse!);

            return IotaSDKResponse<PreparedTransactionData>.CreateInstance(accountResponse);
        }
    }
}
