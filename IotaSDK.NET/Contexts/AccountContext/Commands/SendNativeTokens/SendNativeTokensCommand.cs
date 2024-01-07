using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendNativeTokens
{
    internal class SendNativeTokensCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SendNativeTokensCommand(IntPtr walletHandle, int accountIndex, List<SendNativeTokensOptions> sendNativeTokensOptions, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            SendNativeTokensOptions = sendNativeTokensOptions;
            TransactionOptions = transactionOptions;
        }

        public List<SendNativeTokensOptions> SendNativeTokensOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
