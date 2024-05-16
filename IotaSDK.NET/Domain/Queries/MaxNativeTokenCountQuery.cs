using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs that have at most a certain number of distinct native tokens.
    /// </summary>
    public class MaxNativeTokenCountQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public MaxNativeTokenCountQuery(ulong maxNativeTokenCount)
        {
            MaxNativeTokenCount = maxNativeTokenCount;
        }

        public ulong MaxNativeTokenCount { get; }
    }

}
