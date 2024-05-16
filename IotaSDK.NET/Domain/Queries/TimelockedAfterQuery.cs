using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that are timelocked after a certain Unix timestamp.
    /// </summary>
    public class TimelockedAfterQuery : IQueryParameter, INftQueryParameter
    {
        public TimelockedAfterQuery(ulong timelockedAfter)
        {
            TimelockedAfter = timelockedAfter;
        }

        public ulong TimelockedAfter { get; }
    }

}
