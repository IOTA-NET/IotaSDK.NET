namespace IotaSDK.NET.Domain.Options.PrepareOutput
{
    /// <summary>
    /// Storage deposit strategy to be used for the output
    /// </summary>
    public class PrepareOutputStorageDepositOptions
    {
        public PrepareOutputStorageDepositOptions(PrepareOutputReturnStrategyType returnStrategy, bool? useExcessIfLow)
        {
            ReturnStrategy = returnStrategy.ToString();
            UseExcessIfLow = useExcessIfLow;
        }

        /// <summary>
        /// The return strategy
        /// </summary>
        public string ReturnStrategy { get; }

        /// <summary>
        /// Determines whether the storage deposit will automatically add excess small funds when necessary.
        /// For example, given an account has 20 tokens and wants to send 15 tokens, and the minimum storage deposit
        /// is 10 tokens, it wouldn't be possible to create an output with the 5 token remainder. If this flag is enabled,
        /// the 5 tokens will be added to the output automatically.
        /// </summary>
        public bool? UseExcessIfLow { get; }
    }

    public enum PrepareOutputReturnStrategyType
    {
        Return,
        Gift
    }
}
