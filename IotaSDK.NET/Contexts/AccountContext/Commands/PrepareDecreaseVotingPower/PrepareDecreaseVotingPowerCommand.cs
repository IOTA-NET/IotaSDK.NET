using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDecreaseVotingPower
{
    internal class PrepareDecreaseVotingPowerCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareDecreaseVotingPowerCommand(IntPtr walletHandle, int accountIndex, uint votingPower) : base(walletHandle, accountIndex)
        {
            VotingPower = votingPower;
        }

        public uint VotingPower { get; }
    }
}
