namespace IotaSDK.NET.Contexts.AccountContext.Commands.UnregisterParticipationEvent
{
    internal class UnregisterParticipationEventCommandModelData
    {
        public UnregisterParticipationEventCommandModelData(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; }
    }
}
