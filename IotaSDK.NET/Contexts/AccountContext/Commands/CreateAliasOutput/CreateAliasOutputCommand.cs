using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.CreateAliasOutput
{
    internal class CreateAliasOutputCommand : AccountRequest<IotaSDKResponse<Transaction>>
    {
        public CreateAliasOutputCommand(IntPtr walletHandle, int accountIndex, AliasOutputCreationOptions? aliasOutputCreationOptions = null, TransactionOptions? transactionOptions = null) : base(walletHandle, accountIndex)
        {
            AliasOutputCreationOptions = aliasOutputCreationOptions;
            TransactionOptions = transactionOptions;
        }

        public AliasOutputCreationOptions? AliasOutputCreationOptions { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
