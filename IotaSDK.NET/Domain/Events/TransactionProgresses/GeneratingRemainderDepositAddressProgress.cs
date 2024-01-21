namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    /// A 'generating remainder deposit address' progress.
    /// </summary>
    public class GeneratingRemainderDepositAddressProgress : TransactionProgress
    {
        public GeneratingRemainderDepositAddressProgress() : base((int)TransactionProgressType.GeneratingRemainderDepositAddress)
        {
        }
    }
}
