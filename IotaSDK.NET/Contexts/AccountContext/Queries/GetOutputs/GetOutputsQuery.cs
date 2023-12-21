using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutputs
{
    internal class GetOutputsQuery : AccountRequest<IotaSDKResponse<List<OutputData>>>
    {

        public GetOutputsQuery(IntPtr walletHandle, int accountIndex, OutputFilterOptions? outputFilterOptions) : base(walletHandle, accountIndex)
        {
            OutputFilterOptions = outputFilterOptions;
        }

        public OutputFilterOptions? OutputFilterOptions { get; }
    }
}
