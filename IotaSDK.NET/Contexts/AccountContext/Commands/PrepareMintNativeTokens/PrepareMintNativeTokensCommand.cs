using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Serializers;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using Newtonsoft.Json;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMintNativeTokens
{
    internal class PrepareMintNativeTokensCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareMintNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToMint, TransactionOptions? transactionOptions = null) : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
            NumberOfTokensToMint = numberOfTokensToMint;
            TransactionOptions = transactionOptions;
        }

        public string TokenId { get; }

        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger NumberOfTokensToMint { get; }

        public TransactionOptions? TransactionOptions { get; }
    }
}
