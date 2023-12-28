using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MeltNativeTokens
{
    internal class MeltNativeTokensCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public MeltNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
            NumberOfTokensToMelt = numberOfTokensToMelt;
            TransactionOptions = transactionOptions;
        }

        public string TokenId { get; }
        public BigInteger NumberOfTokensToMelt { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
