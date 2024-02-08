namespace IotaSDK.NET.Domain.ParticipationEvents
{
    public class StakingEventPayload : ParticipationEventPayload
    {
        public StakingEventPayload(string text, string symbol, string numerator, string denominator, string requiredMinimumRewards, string additionalInfo) : base((int)ParticipationEventType.Staking)
        {
            Text = text;
            Symbol = symbol;
            Numerator = numerator;
            Denominator = denominator;
            RequiredMinimumRewards = requiredMinimumRewards;
            AdditionalInfo = additionalInfo;
        }

        /// <summary>
        /// The description text of the staking event.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The symbol of the rewarded tokens. 
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Used in combination with Denominator to calculate the rewards per milestone per staked tokens.
        /// </summary>
        public string Numerator { get; }

        /// <summary>
        /// Used in combination with Numerator to calculate the rewards per milestone per staked tokens.
        /// </summary>
        public string Denominator { get; }

        /// <summary>
        ///  The minimum rewards required to be included in the staking results.
        /// </summary>
        public string RequiredMinimumRewards { get; }

        /// <summary>
        /// Additional description text about the staking event.
        /// </summary>
        public string AdditionalInfo { get; }
    }
}
