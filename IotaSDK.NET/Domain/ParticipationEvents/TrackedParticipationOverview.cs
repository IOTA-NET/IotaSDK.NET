using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// Holds the information for each tracked participation.
    /// </summary>
    public class TrackedParticipationOverview
    {
        public TrackedParticipationOverview(string amount, List<int> answers, string blockId, int endMilestoneIndex, int startMilestoneIndex)
        {
            Amount = amount;
            Answers = answers;
            BlockId = blockId;  
            EndMilestoneIndex = endMilestoneIndex;
            StartMilestoneIndex = startMilestoneIndex;
        }
        /// <summary>
        /// Amount of tokens that were included in the output the participation was made.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// IDs of the answers to the questions of a ballot, in the same order.
        /// </summary>
        public List<int> Answers { get; set; }

        /// <summary>
        /// ID of the block that included the transaction that created the output the participation was made.
        /// </summary>
        public string BlockId { get; set; }

        /// <summary>
        /// Milestone index the participation ended. 0 if the participation is still active.
        /// </summary>
        public int EndMilestoneIndex { get; set; }

        /// <summary>
        /// Milestone index the participation started.
        /// </summary>
        public int StartMilestoneIndex { get; set; }
    }
}
