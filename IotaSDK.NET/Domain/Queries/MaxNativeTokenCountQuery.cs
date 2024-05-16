namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs that have at most a certain number of distinct native tokens.
    /// </summary>
    public class MaxNativeTokenCountQuery
    {
        public MaxNativeTokenCountQuery(ulong maxNativeTokenCount)
        {
            MaxNativeTokenCount = maxNativeTokenCount;
        }

        public ulong MaxNativeTokenCount { get; }
    }

}
