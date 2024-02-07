using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareStopParticipating
{
    internal class PrepareStopParticipatingCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareStopParticipatingCommand(IntPtr walletHandle, int accountIndex, string participationEventId) : base(walletHandle, accountIndex)
        {
            ParticipationEventId = participationEventId;
        }

        public string ParticipationEventId { get; }
    }
}
