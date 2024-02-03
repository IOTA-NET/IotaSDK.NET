using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareVote
{
    internal class PrepareVoteCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareVoteCommand(IntPtr walletHandle, int accountIndex, string? participationEventId=null, List<int>? answers=null) 
            : base(walletHandle, accountIndex)
        {
            ParticipationEventId = participationEventId;
            Answers = answers;
        }

        public string? ParticipationEventId { get; }
        public List<int>? Answers { get; }
    }
}
