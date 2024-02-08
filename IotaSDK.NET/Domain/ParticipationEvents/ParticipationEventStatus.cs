using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// The participation event status.
    /// </summary>
    public class ParticipationEventStatus
    {
        public ParticipationEventStatus(int milestoneIndex, string status, List<QuestionStatus>? questions, string checksum)
        {
            MilestoneIndex = milestoneIndex;
            Status = status;
            Questions = questions;
            Checksum = checksum;
        }

        /// <summary>
        /// The milestone index the status was calculated for.
        /// </summary>
        public int MilestoneIndex { get; }

        /// <summary>
        /// The overall status of the event.
        /// </summary>
        public string Status { get; }
        
        /// <summary>
        /// The answer status of the different questions of the event.
        /// </summary>
        public List<QuestionStatus>? Questions { get; }

        /// <summary>
        /// Checksum is the SHA256 checksum of all the question and answer status or the staking amount and rewards calculated for this milestone index.
        /// </summary>
        public string Checksum { get; }
    }
}
