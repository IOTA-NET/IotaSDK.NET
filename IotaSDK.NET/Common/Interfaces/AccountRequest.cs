using System;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class AccountRequest : WalletRequest
    {
        protected AccountRequest(IntPtr walletHandle, int accountIndex) : base(walletHandle)
        {
            AccountIndex = accountIndex;
        }

        public int AccountIndex { get; }
    }
    internal abstract class AccountRequest<TResponse> : WalletRequest<TResponse>
    {
        protected AccountRequest(IntPtr walletHandle, int accountIndex) : base(walletHandle)
        {
            AccountIndex = accountIndex;
        }

        public int AccountIndex { get; }
    }
}
