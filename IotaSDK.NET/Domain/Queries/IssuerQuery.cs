using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter for a certain issuer
    /// </summary>
    public class IssuerQuery : IQueryParameter, IAliasQueryParameter, INftQueryParameter
    {
        public IssuerQuery(string issuer)
        {
            Issuer = issuer;
        }

        public string Issuer { get; }
    }

}
