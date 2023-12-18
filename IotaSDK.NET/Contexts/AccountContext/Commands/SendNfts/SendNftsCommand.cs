using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Transactions;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendNfts
{
    internal class SendNftsCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SendNftsCommand(IntPtr walletHandle, int accountIndex, List<AddressAndNftId> addressAndNftIds, TransactionOptions? transactionOptions) 
            : base(walletHandle, accountIndex)
        {
            AddressAndNftIds = addressAndNftIds;
            TransactionOptions = transactionOptions;
        }

        public List<AddressAndNftId> AddressAndNftIds { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
