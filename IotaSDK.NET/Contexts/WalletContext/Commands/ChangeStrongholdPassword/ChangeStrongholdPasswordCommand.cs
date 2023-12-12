using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.ChangeStrongholdPassword
{
    internal class ChangeStrongholdPasswordCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public ChangeStrongholdPasswordCommand(IntPtr walletHandle, string currentPassword, string newPassword) : base(walletHandle)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

        public string CurrentPassword { get; }
        public string NewPassword { get; }
    }
}
