namespace IotaSDK.NET.Domain.ParticipationEvents
{
    /// <summary>
    /// The answer status.
    /// </summary>
    public class AnswerStatus
    {
        public AnswerStatus(int value, int current, int accumulated)
        {
            Value = value;
            Current = current;
            Accumulated = accumulated;
        }

        /// <summary>
        /// The value that identifies this answer.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The current voting weight of the answer.
        /// </summary>
        public int Current { get; }

        /// <summary>
        /// The accumulated voting weight of the answer.
        /// </summary>
        public int Accumulated { get; }
    }
}
