namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of storage deposit return unlock condition.
    /// </summary>
    public class HasStorageDepositReturnQuery
    {
        public HasStorageDepositReturnQuery(bool hasStorageDepositReturn)
        {
            HasStorageDepositReturn = hasStorageDepositReturn;
        }

        public bool HasStorageDepositReturn { get; }
    }

}
