using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Queries;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.ClientContext.Queries.GetNftOutputIds
{
    /// <summary>
    /// Get the corresponding output IDs given a list of NFT query parameters.
    /// </summary>
    internal class GetNftOutputIdsQuery : ClientRequest<IotaSDKResponse<ClientOutputsResponse>>
    {
        public GetNftOutputIdsQuery(IntPtr clientHandle, List<INftQueryParameter> queryParameters) : base(clientHandle)
        {
            QueryParameters = queryParameters;
        }

        public List<INftQueryParameter> QueryParameters { get; }
    }
}
