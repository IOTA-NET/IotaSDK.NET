using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that were created before a certain Unix timestamp.
    /// </summary>
    public class CreatedBeforeQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public CreatedBeforeQuery(ulong createdBefore)
        {
            CreatedBefore = createdBefore;
        }

        public ulong CreatedBefore { get; }
    }

}
