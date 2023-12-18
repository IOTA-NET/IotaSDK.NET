using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using System;

namespace IotaSDK.NET.Contexts.WalletContext.Commands.ClearStrongholdPassword
{
    internal class ClearStrongholdPasswordCommand : WalletRequest<IotaSDKResponse<bool>>
    {
        public ClearStrongholdPasswordCommand(IntPtr walletHandle) : base(walletHandle)
        {
        }
    }
}
