using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Pass the cursor(confirmationMS+outputId.pageSize) to start the results from
    /// </summary>
    public class CursorQuery : ICommonQueryParameters, IGenericQueryParameter
    {
        public CursorQuery(string cursor)
        {
            Cursor = cursor;
        }

        public string Cursor { get; }
    }

}
