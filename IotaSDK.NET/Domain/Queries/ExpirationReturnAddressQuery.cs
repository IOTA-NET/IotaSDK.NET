using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter outputs based on the presence of a specific Bech32-encoded return
    /// address in the expiration unlock condition.
    /// </summary>
    public class ExpirationReturnAddressQuery : IQueryParameter, INftQueryParameter
    {
        public ExpirationReturnAddressQuery(string expirationReturnAddress)
        {
            ExpirationReturnAddress = expirationReturnAddress;
        }

        public string ExpirationReturnAddress { get; }
    }

}
