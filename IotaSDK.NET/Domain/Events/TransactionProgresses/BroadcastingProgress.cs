namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    ///  A 'broadcasting' progress.
    /// </summary>
    public class BroadcastingProgress : TransactionProgress
    {
        public BroadcastingProgress() : base((int)TransactionProgressType.Broadcasting)
        {
        }
    }
}
