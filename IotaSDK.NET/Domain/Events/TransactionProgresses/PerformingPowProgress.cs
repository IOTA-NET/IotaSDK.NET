namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    ///  A 'performing PoW' progress.
    /// </summary>
    public class PerformingPowProgress : TransactionProgress
    {
        public PerformingPowProgress() : base((int)TransactionProgressType.PerformingPow)
        {
        }
    }
}
