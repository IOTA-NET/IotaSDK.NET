namespace IotaSDK.NET.Domain.Transactions.Payloads
{
    /// <summary>
    /// All of the block payload types.
    /// </summary>
    public enum PayloadType
    {
        /** A milestone payload. */
        Milestone = 7,
        /** A tagged data payload. */
        TaggedData = 5,
        /** A transaction payload. */
        Transaction = 6,
        /** A treasury transaction payload. */
        TreasuryTransaction = 4,
    }
}
