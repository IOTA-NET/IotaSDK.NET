using IotaSDK.NET.Domain.Queries;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNftOutputIds
{
    internal class GetNftOutputIdsQueryModelData
    {
        public GetNftOutputIdsQueryModelData(List<INftQueryParameter> queryParameters)
        {
            QueryParameters = queryParameters;
        }

        public List<INftQueryParameter> QueryParameters { get; }
    }
}
