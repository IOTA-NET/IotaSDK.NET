using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter for a certain sender
    /// </summary>
    public class SenderQuery : IQueryParameter, IAliasQueryParameter, INftQueryParameter
    {
        public SenderQuery(string sender)
        {
            Sender = sender;
        }

        public string Sender { get; }
    }

}
