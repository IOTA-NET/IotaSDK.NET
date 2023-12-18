using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft
{
    internal class PrepareBurnNftCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareBurnNftCommand(IntPtr walletHandle, int accountIndex, string nftId, TransactionOptions? transactionOptions) : base(walletHandle, accountIndex)
        {
            NftId = nftId;
            TransactionOptions = transactionOptions;
        }

        public string NftId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
