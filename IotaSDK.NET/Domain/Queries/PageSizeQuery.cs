using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /** Define the page size for the results. */
    public class PageSizeQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public ulong PageSize { get; }

        public PageSizeQuery(ulong pageSize)
        {
            PageSize = pageSize;
        }
    }

}
