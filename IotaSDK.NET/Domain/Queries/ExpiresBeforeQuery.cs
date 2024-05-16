using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that expire before a certain Unix timestamp. 
    /// </summary>
    public class ExpiresBeforeQuery : IQueryParameter, INftQueryParameter
    {
        public ExpiresBeforeQuery(ulong expiresBefore)
        {
            ExpiresBefore = expiresBefore;
        }

        public ulong ExpiresBefore { get; }
    }

}
