namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareStopParticipating
{
    internal class PrepareStopParticipatingCommandModelData
    {
        public PrepareStopParticipatingCommandModelData(string eventId)
        {
            EventId = eventId;
        }

        public string EventId { get; }
    }
}
