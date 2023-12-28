using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.ClaimOutputs
{
    internal class ClaimOutputsCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public ClaimOutputsCommand(IntPtr walletHandle, int accountIndex, List<string> outputIds)
            : base(walletHandle, accountIndex)
        {
            OutputIds = outputIds;
        }

        public List<string> OutputIds { get; }
    }
}
