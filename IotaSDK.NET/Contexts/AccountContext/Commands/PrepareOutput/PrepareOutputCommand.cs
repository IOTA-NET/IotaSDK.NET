using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options.PrepareOutput;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareOutput
{
    internal class PrepareOutputCommand : AccountRequest<IotaSDKResponse<Output>>
    {
        public PrepareOutputCommand(IntPtr walletHandle, int accountIndex, PrepareOutputOptions prepareOutputOptions, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            PrepareOutputOptions = prepareOutputOptions;
            TransactionOptions = transactionOptions;
        }

        public PrepareOutputOptions PrepareOutputOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
