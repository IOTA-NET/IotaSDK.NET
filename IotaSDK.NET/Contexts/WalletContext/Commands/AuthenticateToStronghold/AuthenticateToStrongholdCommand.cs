using IotaSDK.NET.Common.Interfaces;
using MediatR;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold
{
    internal class AuthenticateToStrongholdCommand : IRequest<IotaSDKResponse<bool>>
    {
        public AuthenticateToStrongholdCommand(IntPtr walletHandle, string password)
        {
            Password = password;
            WalletHandle = walletHandle;

        }
        public IntPtr WalletHandle { get; }

        public string Password { get; }
    }
}
