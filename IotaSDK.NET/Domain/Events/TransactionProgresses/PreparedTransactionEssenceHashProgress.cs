namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    /// A 'prepared transaction essence hash' progress.
    /// </summary>
    public class PreparedTransactionEssenceHashProgress : TransactionProgress
    {
        public PreparedTransactionEssenceHashProgress(string hash) : base((int)TransactionProgressType.PreparedTransactionEssenceHash)
        {
            Hash = hash;
        }

        /// <summary>
        /// The hash of the transaction essence.
        /// </summary>
        public string Hash { get; }
    }
}
