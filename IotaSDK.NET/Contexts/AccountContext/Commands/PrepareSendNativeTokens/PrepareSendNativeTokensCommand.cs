using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNativeTokens
{
    internal class PrepareSendNativeTokensCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareSendNativeTokensCommand(IntPtr walletHandle, int accountIndex, List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            SendNativeTokensOptions = sendNativeTokensOptions;
            TransactionOptions = transactionOptions;
        }

        public List<SendNativeTokensOptions> SendNativeTokensOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
