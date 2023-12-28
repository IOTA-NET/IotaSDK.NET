using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Signatures;
using IotaSDK.NET.Domain.Transactions.Prepared;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignTransactionEssence
{
    internal class SignTransactionEssenceCommand : AccountRequest<IotaSDKResponse<SignedTransactionEssence>>
    {
        public SignTransactionEssenceCommand(IntPtr walletHandle, int accountIndex, PreparedTransactionData preparedTransactionData)
            : base(walletHandle, accountIndex)
        {
            PreparedTransactionData = preparedTransactionData;
        }

        public PreparedTransactionData PreparedTransactionData { get; }
    }
}
