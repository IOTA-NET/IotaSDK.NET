using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.AuthenticateToStronghold
{
    internal class AuthenticateToStrongholdCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public AuthenticateToStrongholdCommand(IntPtr walletHandle, string password) : base(walletHandle)
        {
            Password = password;

        }
        public string Password { get; }
    }
}
