using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetUnspentOutputs
{
    internal class GetUnspentOutputsQuery : AccountRequest<IotaSDKResponse<List<OutputData>>>
    {
        public GetUnspentOutputsQuery(IntPtr walletHandle, int accountIndex, OutputFilterOptions? filterOptions=null) : base(walletHandle, accountIndex)
        {
            FilterOptions = filterOptions;
        }

        public OutputFilterOptions? FilterOptions { get; }
    }
}
