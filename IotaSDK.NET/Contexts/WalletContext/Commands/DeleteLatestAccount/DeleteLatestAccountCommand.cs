using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
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
