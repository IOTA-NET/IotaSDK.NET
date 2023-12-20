using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.RetryTransactionUntilIncluded
{
    /// <summary>
    /// Retries (promotes or reattaches) a transaction sent from the account for a provided transaction id until it's
    /// included (referenced by a milestone). Returns the included block id
    /// </summary>
    internal class RetryTransactionUntilIncludedCommand : AccountRequest<IotaSDKResponse<string>>
    {
        public RetryTransactionUntilIncludedCommand(IntPtr walletHandle, int accountIndex, string transactionId, int? interval, int? maxAttempts) : base(walletHandle, accountIndex)
        {
            TransactionId = transactionId;
            Interval = interval;
            MaxAttempts = maxAttempts;
        }

        public string TransactionId { get; }
        public int? Interval { get; }
        public int? MaxAttempts { get; }
    }
}
