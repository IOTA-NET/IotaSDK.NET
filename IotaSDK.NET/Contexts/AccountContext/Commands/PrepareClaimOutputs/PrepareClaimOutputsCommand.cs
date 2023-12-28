using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareClaimOutputs
{
    internal class PrepareClaimOutputsCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareClaimOutputsCommand(IntPtr walletHandle, int accountIndex, List<string> outputIds)
            : base(walletHandle, accountIndex)
        {
            OutputIds = outputIds;
        }

        public List<string> OutputIds { get; }
    }
}
