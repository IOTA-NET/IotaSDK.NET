using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Accounts;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.CreateAccount
{
    internal class CreateAccountCommand : WalletRequest<IotaSDKResponse<AccountMeta>>
    {
        public CreateAccountCommand(IntPtr walletHandle, string? username=null) : base(walletHandle)
        {
            Username = username;
        }
        public string? Username { get; }
    }
}
