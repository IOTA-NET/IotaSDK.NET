using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of expiration unlock condition.
    /// </summary>
    public class HasExpirationQuery : IQueryParameter, INftQueryParameter
    {
        public HasExpirationQuery(bool hasExpiration)
        {
            HasExpiration = hasExpiration;
        }

        public bool HasExpiration { get; }
    }

}
