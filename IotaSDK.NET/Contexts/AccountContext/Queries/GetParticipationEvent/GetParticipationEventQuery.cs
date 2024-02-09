using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.ParticipationEvents;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvent
{
    internal class GetParticipationEventQuery : AccountRequest<IotaSDKResponse<ParticipationEventWithNodes>>
    {
        public GetParticipationEventQuery(IntPtr walletHandle, int accountIndex, string participationEventId) : base(walletHandle, accountIndex)
        {
            ParticipationEventId = participationEventId;
        }

        public string ParticipationEventId { get; }
    }
}
