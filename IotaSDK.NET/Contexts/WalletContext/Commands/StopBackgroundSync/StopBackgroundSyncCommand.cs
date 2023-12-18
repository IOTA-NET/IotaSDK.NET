using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.StopBackgroundSync
{
    internal class StopBackgroundSyncCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public StopBackgroundSyncCommand(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
