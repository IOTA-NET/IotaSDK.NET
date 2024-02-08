namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetParticipationEventStatus
{
    internal class GetParticipationEventStatusQueryModelData
    {
        public GetParticipationEventStatusQueryModelData(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; }
    }
}
