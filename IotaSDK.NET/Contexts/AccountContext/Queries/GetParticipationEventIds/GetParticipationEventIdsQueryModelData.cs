using IotaSDK.NET.Domain.Network;
using IotaSDK.NET.Domain.ParticipationEvents;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventIds
{
    internal class GetParticipationEventIdsQueryModelData
    {
        public GetParticipationEventIdsQueryModelData(Node node, ParticipationEventType? eventType = null)
        {
            Node = node;
            EventType = eventType;
        }

        public Node Node { get; }
        public ParticipationEventType? EventType { get; }
    }
}
