using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexQuery : WalletRequest<IotaSDKResponse<IAccount>>
    {
        public GetAccountWithIndexQuery(IntPtr walletHandle, int index) : base(walletHandle)
        {
            Index = index;
        }

        public int Index { get; }
    }
}
