using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasCommand : WalletRequest<IotaSDKResponse<IAccount>>
    {
        public GetAccountWithAliasCommand(IntPtr walletHandle, string alias) : base(walletHandle)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
