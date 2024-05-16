using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Return outputs that are timelocked before a certain Unix timestamp.
    /// </summary>
    public class TimelockedBeforeQuery : IQueryParameter, INftQueryParameter
    {
        public TimelockedBeforeQuery(ulong timelockedBefore)
        {
            TimelockedBefore = timelockedBefore;
        }

        public ulong TimelockedBefore { get; }
    }

}
