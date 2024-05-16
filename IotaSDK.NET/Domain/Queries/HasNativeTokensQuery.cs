using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filters outputs based on the presence of native tokens.
    /// </summary>
    public class HasNativeTokensQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public HasNativeTokensQuery(bool hasNativeTokens)
        {
            HasNativeTokens = hasNativeTokens;
        }

        public bool HasNativeTokens { get; }
    }

}
