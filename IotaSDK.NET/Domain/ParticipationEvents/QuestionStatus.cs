using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// The question status.
    /// </summary>
    public class QuestionStatus
    {
        public QuestionStatus(List<AnswerStatus> answers)
        {
            Answers = answers;
        }

        /// <summary>
        /// The status of the answers. 
        /// </summary>
        public List<AnswerStatus> Answers { get; }
    }
}
