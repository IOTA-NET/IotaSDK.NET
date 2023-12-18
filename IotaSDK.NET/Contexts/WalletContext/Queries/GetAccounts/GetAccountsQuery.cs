using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts
{
    internal class GetAccountsQuery : WalletRequest<IotaSDKResponse<List<AccountMeta>>>
    {
        public GetAccountsQuery(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
