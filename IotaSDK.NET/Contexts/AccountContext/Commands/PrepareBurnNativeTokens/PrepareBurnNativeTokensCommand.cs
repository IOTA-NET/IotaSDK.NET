using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens
{
    internal class PrepareBurnNativeTokensCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareBurnNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
            NumberOfTokensToBurn = numberOfTokensToBurn;
            TransactionOptions = transactionOptions;
        }

        public string TokenId { get; }
        public BigInteger NumberOfTokensToBurn { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
