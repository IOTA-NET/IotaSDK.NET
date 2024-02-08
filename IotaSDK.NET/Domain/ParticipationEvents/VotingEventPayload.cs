using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    public class VotingEventPayload : ParticipationEventPayload
    {
        public VotingEventPayload(List<Question> questions) : base((int)ParticipationEventType.Voting)
        {
            Questions = questions;
        }

        /// <summary>
        /// The questions to vote on.
        /// </summary>
        public List<Question> Questions { get; }
    }
}
