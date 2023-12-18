using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction
{
    internal class SignAndSubmitTransactionCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {

        public SignAndSubmitTransactionCommand(IntPtr walletHandle, int accountIndex, PreparedTransactionData preparedTransactionData) : base(walletHandle, accountIndex)
        {
            PreparedTransactionData = preparedTransactionData;
        }

        public PreparedTransactionData PreparedTransactionData { get; }
    }
}
