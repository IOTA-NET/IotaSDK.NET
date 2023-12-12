using IotaSDK.NET.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccounts
{
    internal class GetAccountsQuery : WalletRequest<IotaSDKResponse<List<IAccount>>>
    {
        public GetAccountsQuery(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
