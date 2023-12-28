using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.BurnNft
{
    internal class BurnNftCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {

        public BurnNftCommand(IntPtr walletHandle, int accountIndex, string nftId, TransactionOptions? transactionOptions = null) : base(walletHandle, accountIndex)
        {
            NftId = nftId;
            TransactionOptions = transactionOptions;
        }
        public string NftId { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
