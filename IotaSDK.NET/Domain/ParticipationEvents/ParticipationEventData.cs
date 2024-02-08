namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// Metadata about a participation event.
    /// </summary>
    public class ParticipationEventData
    {
        public ParticipationEventData(string name, int milestoneIndexCommence, int milestoneIndexStart, int milestoneIndexEnd, ParticipationEventPayload payload, string additionalInfo)
        {
            Name = name;
            MilestoneIndexCommence = milestoneIndexCommence;
            MilestoneIndexStart = milestoneIndexStart;
            MilestoneIndexEnd = milestoneIndexEnd;
            Payload = payload;
            AdditionalInfo = additionalInfo;
        }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The milestone index the commencing period starts.
        /// </summary>
        public int MilestoneIndexCommence { get; }

        /// <summary>
        /// The milestone index the holding period starts.
        /// </summary>
        public int MilestoneIndexStart { get; }

        /// <summary>
        /// The milestone index the event ends.
        /// </summary>
        public int MilestoneIndexEnd { get; }

        /// <summary>
        /// The payload of the event (voting or staking).
        /// </summary>
        public ParticipationEventPayload Payload { get; }

        /// <summary>
        ///  Some additional description text about the event.
        /// </summary>
        public string AdditionalInfo { get; }
    }
}
