using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.ConsolidateOutputs
{
    internal class ConsolidateOutputsCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public ConsolidateOutputsCommand(IntPtr walletHandle, int accountIndex, ConsolidationOptions consolidationOptions)
            : base(walletHandle, accountIndex)
        {
            ConsolidationOptions = consolidationOptions;
        }

        public ConsolidationOptions ConsolidationOptions { get; }
    }
}
