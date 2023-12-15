using MediatR;
using System;

namespace IotaSDK.NET.Common.Interfaces
{

    internal abstract class WalletRequest : IRequest
    {
        public WalletRequest(IntPtr walletHandle)
        {
            WalletHandle = walletHandle;
        }

        public IntPtr WalletHandle { get; }
    }

    internal abstract class WalletRequest<TResponse> :IRequest<TResponse>
    {
        public WalletRequest(IntPtr walletHandle)
        {
            WalletHandle = walletHandle;
        }

        public IntPtr WalletHandle { get; }
    }

}
