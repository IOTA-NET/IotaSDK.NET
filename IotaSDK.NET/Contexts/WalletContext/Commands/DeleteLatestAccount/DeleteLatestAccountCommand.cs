using IotaSDK.NET.Common.Interfaces;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.DeleteLatestAccount
{
    internal class DeleteLatestAccountCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public DeleteLatestAccountCommand(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
