using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter outputs based on the presence of a specific Bech32-encoded return address
    /// in the storage deposit return unlock condition.
    /// </summary>
    public class StorageDepositReturnAddressQuery : IQueryParameter, INftQueryParameter
    {
        public StorageDepositReturnAddressQuery(string storageDepositReturnAddress)
        {
            StorageDepositReturnAddress = storageDepositReturnAddress;
        }

        public string StorageDepositReturnAddress { get; }
    }

}
