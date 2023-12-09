using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount
{
    internal class CreateAccountCommand : WalletRequest<IotaSDKResponse<IAccount>>
    {
        public CreateAccountCommand(IntPtr walletHandle, string? username=null) : base(walletHandle)
        {
            Username = username;
        }
        public string? Username { get; }
    }
}
