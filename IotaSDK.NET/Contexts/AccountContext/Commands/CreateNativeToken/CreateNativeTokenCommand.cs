using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.CreateNativeToken
{
    internal class CreateNativeTokenCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public CreateNativeTokenCommand(IntPtr walletHandle, int accountIndex, NativeTokenCreationOptions nativeTokenCreationOptions, TransactionOptions? transactionOptions)
        : base(walletHandle, accountIndex)
        {
            NativeTokenCreationOptions = nativeTokenCreationOptions;
            TransactionOptions = transactionOptions;
        }

        public NativeTokenCreationOptions NativeTokenCreationOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
