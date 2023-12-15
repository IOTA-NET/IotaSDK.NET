using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin
{
    internal class SendBaseCoinCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SendBaseCoinCommand(
            IntPtr walletHandle, int accountIndex, 
            ulong amount, string bech32ReceiverAddress, 
            TransactionOptions? transactionOptions=null) 
            : base(walletHandle, accountIndex)
        {
            Amount = amount;
            Bech32ReceiverAddress = bech32ReceiverAddress;
            TransactionOptions = transactionOptions;
        }

        public ulong Amount { get; }
        public string Bech32ReceiverAddress { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
