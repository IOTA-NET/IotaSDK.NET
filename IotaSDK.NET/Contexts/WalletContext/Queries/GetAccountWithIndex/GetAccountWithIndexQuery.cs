using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexQuery : WalletRequest<IotaSDKResponse<AccountMeta>>
    {
        public GetAccountWithIndexQuery(IntPtr walletHandle, int index) : base(walletHandle)
        {
            Index = index;
        }

        public int Index { get; }
    }
}
