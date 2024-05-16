using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that were created after a certain Unix timestamp.
    /// </summary>
    public class CreatedAfterQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public CreatedAfterQuery(ulong createdAfter)
        {
            CreatedAfter = createdAfter;
        }

        public ulong CreatedAfter { get; }
    }

}
