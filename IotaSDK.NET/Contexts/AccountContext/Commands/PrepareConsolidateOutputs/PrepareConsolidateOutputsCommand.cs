using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareConsolidateOutputs
{
    internal class PrepareConsolidateOutputsCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareConsolidateOutputsCommand(IntPtr walletHandle, int accountIndex, ConsolidationOptions consolidationOptions)
            : base(walletHandle, accountIndex)
        {
            ConsolidationOptions = consolidationOptions;
        }

        public ConsolidationOptions ConsolidationOptions { get; }
    }
}
