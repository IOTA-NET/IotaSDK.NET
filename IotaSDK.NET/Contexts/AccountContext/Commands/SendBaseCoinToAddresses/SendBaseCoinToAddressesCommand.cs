using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoinToAddresses
{
    internal class SendBaseCoinToAddressesCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SendBaseCoinToAddressesCommand(IntPtr walletHandle, int accountIndex, SendBaseCoinToAddressOptions sendBaseCoinToAddressOptions, TransactionOptions? transactionOptions = null)
            : base(walletHandle, accountIndex)
        {
            SendBaseCoinToAddressOptions = sendBaseCoinToAddressOptions;
            TransactionOptions = transactionOptions;
        }

        public SendBaseCoinToAddressOptions SendBaseCoinToAddressOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
