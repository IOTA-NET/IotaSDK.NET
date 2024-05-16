using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs that have at least a certain number of distinct native tokens.
    /// </summary>
    public class MinNativeTokenCountQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public MinNativeTokenCountQuery(ulong minNativeTokenCount)
        {
            MinNativeTokenCount = minNativeTokenCount;
        }

        public ulong MinNativeTokenCount { get; }
    }

}
