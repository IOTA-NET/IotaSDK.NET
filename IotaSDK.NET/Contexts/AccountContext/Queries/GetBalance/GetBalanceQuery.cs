using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.AccountContext.Queries.GetBalance
{
    internal class GetBalanceQuery : AccountRequest<IotaSDKResponse<AccountBalance>>
    {
        public GetBalanceQuery(IntPtr walletHandle, int accountIndex) : base(walletHandle, accountIndex)
        {
        }
    }
}
