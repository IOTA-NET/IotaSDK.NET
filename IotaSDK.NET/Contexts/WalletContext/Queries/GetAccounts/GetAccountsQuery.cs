using IotaSDK.NET.Common.Interfaces;
using System;
using System.Collections.Generic;
using IotaSDK.NET.Domain.Accounts;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts
{
    internal class GetAccountsQuery : WalletRequest<IotaSDKResponse<List<AccountMeta>>>
    {
        public GetAccountsQuery(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
