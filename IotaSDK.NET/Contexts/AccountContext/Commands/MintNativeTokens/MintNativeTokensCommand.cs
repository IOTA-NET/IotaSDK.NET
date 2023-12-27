using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.MintNativeTokens
{
    internal class MintNativeTokensCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public MintNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null) : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
            NumberOfTokensToMint = numberOfTokensToMint;
            TransactionOptions = transactionOptions;
        }

        public string TokenId { get; }
        public BigInteger NumberOfTokensToMint { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
