namespace IotaSDK.NET.Domain.Options.PrepareOutput
{
    /// <summary>
    /// Time unlocks to include in the output
    /// </summary>
    public class PrepareOutputUnlockOptions
    {
        public PrepareOutputUnlockOptions(ulong? expirationUnixTime, ulong? timelockUnixTime)
        {
            ExpirationUnixTime = expirationUnixTime;
            TimelockUnixTime = timelockUnixTime;
        }

        /// <summary>
        /// The expiration Unix timestamp that marks the end of the expiration period
        /// </summary>
        public ulong? ExpirationUnixTime { get; }

        /// <summary>
        /// The timelock Unix timestamp that marks the end of the locking period
        /// </summary>
        public ulong? TimelockUnixTime { get; }
    }
}
