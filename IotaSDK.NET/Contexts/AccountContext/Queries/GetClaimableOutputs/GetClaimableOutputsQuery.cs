using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Outputs;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetClaimableOutputs
{
    internal class GetClaimableOutputsQuery : AccountRequest<IotaSDKResponse<List<string>>>
    {
        public GetClaimableOutputsQuery(IntPtr walletHandle, int accountIndex, ClaimableOutputType claimableOutputType) : base(walletHandle, accountIndex)
        {
            ClaimableOutputType = claimableOutputType;
        }

        public ClaimableOutputType ClaimableOutputType { get; }
    }
}
