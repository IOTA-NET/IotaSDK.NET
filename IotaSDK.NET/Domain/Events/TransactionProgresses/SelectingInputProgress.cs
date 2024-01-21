namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    /// A 'selecting inputs' progress.
    /// </summary>
    public class SelectingInputProgress : TransactionProgress
    {
        public SelectingInputProgress() : base((int)TransactionProgressType.SelectingInputs)
        {
        }
    }
}
