using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.ParticipationEvents;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvents
{
    internal class GetParticipationEventsQuery : AccountRequest<IotaSDKResponse<ParticipationEventMap>>
    {
        public GetParticipationEventsQuery(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
