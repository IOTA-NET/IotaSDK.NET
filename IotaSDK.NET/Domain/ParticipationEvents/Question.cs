using System.Collections.Generic;

namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// Defines a single question inside a Ballot that can have multiple answers.
    /// </summary>
    public class Question
    {
        public Question(string text, List<string> answers, string additionalInfo)
        {
            Text = text;
            Answers = answers;
            AdditionalInfo = additionalInfo;
        }

        /// <summary>
        /// The text of the question.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The possible answers to the question.
        /// </summary>
        public List<string> Answers { get; }

        /// <summary>
        /// Some additional description text about the question.
        /// </summary>
        public string AdditionalInfo { get; }
    }
}
