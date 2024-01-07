using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Common.Serializers;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using Newtonsoft.Json;
using System;
using System.Numerics;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareMeltNativeTokens
{
    internal class PrepareMeltNativeTokensCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        [JsonConstructor]
        public PrepareMeltNativeTokensCommand(IntPtr walletHandle, int accountIndex, string tokenId, BigInteger numberOfTokensToMelt, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            TokenId = tokenId;
            NumberOfTokensToMelt = numberOfTokensToMelt;
            TransactionOptions = transactionOptions;
        }

        public string TokenId { get; }

        [JsonConverter(typeof(BigIntJsonConverter))]
        public BigInteger NumberOfTokensToMelt { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
