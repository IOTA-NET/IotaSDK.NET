using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.ParticipationEvents;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventIds
{
    internal class GetParticipationEventIdsQuery : AccountRequest<IotaSDKResponse<List<string>>>
    {
        public GetParticipationEventIdsQuery(IntPtr walletHandle, int accountIndex, Node node, ParticipationEventType? eventType=null) : base(walletHandle, accountIndex)
        {
            Node = node;
            EventType = eventType;
        }

        public Node Node { get; }
        public ParticipationEventType? EventType { get; }
    }
}
