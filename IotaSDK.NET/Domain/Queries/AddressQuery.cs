using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Bech32-encoded address that should be searched for.
    /// </summary>
    public class AddressQuery : IQueryParameter, INftQueryParameter
    {
        public AddressQuery(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }

}
