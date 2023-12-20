namespace IotaSDK.NET.Contexts.AccountContext.Commands.RetryTransactionUntilIncluded
{
    internal class RetryTransactionUntilIncludedCommandModelData
    {
        public RetryTransactionUntilIncludedCommandModelData(string transactionId, int? interval, int? maxAttempts)
        {
            TransactionId = transactionId;
            Interval = interval;
            MaxAttempts = maxAttempts;
        }

        public string TransactionId { get; }
        public int? Interval { get; }
        public int? MaxAttempts { get; }
    }
}
