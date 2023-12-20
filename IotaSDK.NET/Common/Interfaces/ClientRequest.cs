using MediatR;
using System;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class ClientRequest : IRequest
    {
        public ClientRequest(IntPtr clientHandle)
        {
            ClientHandle = clientHandle;
        }

        public IntPtr ClientHandle { get; }
    }

    internal abstract class ClientRequest<TResponse> : IRequest<TResponse>
    {
        public ClientRequest(IntPtr walletHandle)
        {
            ClientHandle = walletHandle;
        }

        public IntPtr ClientHandle { get; }
    }
}
