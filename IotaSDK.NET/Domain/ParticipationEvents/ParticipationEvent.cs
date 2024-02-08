namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// A participation event.
    /// </summary>
    public class ParticipationEvent
    {
        public ParticipationEvent(string id, ParticipationEventData data)
        {
            Id = id;
            Data = data;
        }

        /// <summary>
        /// The event ID. 
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Information about a voting or staking event.
        /// </summary>
        public ParticipationEventData Data { get; }
    }
}
