using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNfts
{
    internal class PrepareSendNftsCommand : AccountRequest<IotaSDKResponse<PreparedTransactionData>>
    {
        public PrepareSendNftsCommand(IntPtr walletHandle, int accountIndex, List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions) : base(walletHandle, accountIndex)
        {
            AddressAndNftIds = addressAndNftIds;
            TransactionOptions = transactionOptions;
        }

        public List<AddressAndNftId> AddressAndNftIds { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
