using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithAlias
{
    internal class GetAccountWithAliasQuery : WalletRequest<IotaSDKResponse<AccountMeta>>
    {
        public GetAccountWithAliasQuery(IntPtr walletHandle, string alias) : base(walletHandle)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
