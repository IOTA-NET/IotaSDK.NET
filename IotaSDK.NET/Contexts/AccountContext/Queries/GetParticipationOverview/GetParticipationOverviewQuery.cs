using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.ParticipationEvents;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationOverview
{
    internal class GetParticipationOverviewQuery : AccountRequest<IotaSDKResponse<ParticipationOverview>>
    {
        public GetParticipationOverviewQuery(IntPtr walletHandle, int accountIndex, List<string>? participationEventIds=null) : base(walletHandle, accountIndex)
        {
            ParticipationEventIds = participationEventIds;
        }

        public List<string>? ParticipationEventIds { get; }
    }
}
