using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasQuery : WalletRequest<IotaSDKResponse<IAccount>>
    {
        public GetAccountWithAliasQuery(IntPtr walletHandle, string alias) : base(walletHandle)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
