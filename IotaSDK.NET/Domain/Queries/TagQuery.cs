using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter for a certain tag
    /// </summary>
    public class TagQuery : IQueryParameter, INftQueryParameter
    {
        public TagQuery(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; }
    }

}
