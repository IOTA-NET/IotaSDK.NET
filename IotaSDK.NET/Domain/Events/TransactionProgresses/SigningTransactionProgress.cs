namespace IotaSDK.NET.Domain.Events.TransactionProgresses
{
    /// <summary>
    ///  A 'signing transaction' progress.
    /// </summary>
    public class SigningTransactionProgress : TransactionProgress
    {
        public SigningTransactionProgress() : base((int)TransactionProgressType.PreparedTransactionEssenceHash)
        {
        }
    }
}
