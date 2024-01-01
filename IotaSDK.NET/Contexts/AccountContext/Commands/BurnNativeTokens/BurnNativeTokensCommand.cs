using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.BurnNativeTokens
{
    internal class BurnNativeTokensCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public BurnNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToBurn, TransactionOptions? transactionOptions = null)
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
