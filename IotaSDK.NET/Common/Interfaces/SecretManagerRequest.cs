using MediatR;
using System;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class SecretManagerRequest : IRequest
    {
        public SecretManagerRequest(IntPtr secretManagerHandle)
        {
            SecretManagerHandle = secretManagerHandle;
        }

        public IntPtr SecretManagerHandle { get; }
    }

    internal abstract class SecretManagerRequest<TResponse> : IRequest<TResponse>
    {
        public SecretManagerRequest(IntPtr secretManagerHandle)
        {
            SecretManagerHandle = secretManagerHandle;
        }

        public IntPtr SecretManagerHandle { get; }
    }
}
