namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEvent
{
    internal class GetParticipationEventQueryModelData
    {
        public GetParticipationEventQueryModelData(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; }
    }
}
