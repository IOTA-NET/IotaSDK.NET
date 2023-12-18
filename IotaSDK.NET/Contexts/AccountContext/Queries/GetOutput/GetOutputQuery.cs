using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetOutput
{
    internal class GetOutputQuery : AccountRequest<IotaSDKResponse<OutputData>>
    {
        public GetOutputQuery(IntPtr walletHandle, int accountIndex, string outputId) : base(walletHandle, accountIndex)
        {
            OutputId = outputId;
        }

        public string OutputId { get; }
    }
}
