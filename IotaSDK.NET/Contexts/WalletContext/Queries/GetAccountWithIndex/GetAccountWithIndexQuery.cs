using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Queries.GetAccountWithIndex
{
    internal class GetAccountWithIndexCommand : WalletRequest<IotaSDKResponse<IAccount>>
    {
        public GetAccountWithIndexCommand(IntPtr walletHandle, int index) : base(walletHandle)
        {
            Index = index;
        }

        public int Index { get; }
    }
}
