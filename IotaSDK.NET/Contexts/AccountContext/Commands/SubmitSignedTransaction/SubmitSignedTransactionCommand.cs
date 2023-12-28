using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Signatures;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SubmitSignedTransaction
{
    internal class SubmitSignedTransactionCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public SubmitSignedTransactionCommand(IntPtr walletHandle, int accountIndex, SignedTransactionEssence signedTransactionEssence)
            : base(walletHandle, accountIndex)
        {
            SignedTransactionEssence = signedTransactionEssence;
        }

        public SignedTransactionEssence SignedTransactionEssence { get; }
    }
}
