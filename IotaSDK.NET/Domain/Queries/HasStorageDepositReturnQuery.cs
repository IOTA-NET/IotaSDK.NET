using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of storage deposit return unlock condition.
    /// </summary>
    public class HasStorageDepositReturnQuery: IQueryParameter, INftQueryParameter
    {
        public HasStorageDepositReturnQuery(bool hasStorageDepositReturn)
        {
            HasStorageDepositReturn = hasStorageDepositReturn;
        }

        public bool HasStorageDepositReturn { get; }
    }

}
